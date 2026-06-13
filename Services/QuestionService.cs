using BackOffice.Entity.Products;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class QuestionService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Question>> Get(Guid clientId, int? OPTIONINDEX = null)
        {
            var questionList = new List<Question>();
            var forcedChoicesList = new List<ForceChoice>();
            if (OPTIONINDEX.HasValue)
            {
                var question =
                    await _uow.Question.GetByIdAsync(OPTIONINDEX.Value, true, clientId)
                    ?? throw new Exception("Không tìm thấy câu hỏi");
                questionList.Add(question);

                var forcedChoices = await _uow.ForceChoice.GetAllByQuestion(
                    clientId,
                    OPTIONINDEX.Value
                );
                forcedChoicesList.AddRange(forcedChoices);
            }
            else
            {
                var questions = await _uow.Question.GetAllAsync(true, clientId);
                var questionIds = questions.Select(q => q.OPTIONINDEX).ToList();
                questionList.AddRange(questions);

                var forcedChoices = await _uow.ForceChoice.GetByIdsAsync(
                    questionIds,
                    true,
                    clientId
                );
                forcedChoicesList.AddRange(forcedChoices);
            }

            var joinData = questionList.Select(q =>
            {
                q.ForcedChoices =
                [
                    .. forcedChoicesList.Where(fc => fc.OPTIONINDEX == q.OPTIONINDEX),
                ];
                return q;
            });

            return joinData;
        }

        public async Task<Question> Create(Guid clientId, Question question)
        {
            try
            {
                _uow.BeginTransaction();
                var OPTIONINDEX = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_QUESTIONS,
                    clientId
                );
                question.OPTIONINDEX = OPTIONINDEX;
                question.ClientId = clientId;

                List<ForceChoice> forceChoices = [];

                if (question.ForcedChoices != null && question.ForcedChoices.Count() > 0)
                {
                    var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                        AutoIncType.GETNEXT_ForceChoice,
                        clientId,
                        null,
                        question.ForcedChoices.Count()
                    );

                    int startSequence = nextSequence - question.ForcedChoices.Count() + 1;

                    foreach (var choice in question.ForcedChoices)
                    {
                        choice.UNIQUEID = nextSequence++;
                        choice.OPTIONINDEX = question.OPTIONINDEX;
                        choice.ClientId = clientId;
                        forceChoices.Add(choice);
                    }
                }

                var createdQuestion = await _uow.Question.AddAsync(question);

                if (forceChoices.Count > 0)
                    await _uow.ForceChoice.AddRangeAsync(forceChoices);

                _uow.Commit();
                return createdQuestion;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<Question> Update(Guid clientId, QuestionUpdate updateDto)
        {
            try
            {
                _uow.BeginTransaction();

                var updatedQuestion = await _uow.Question.UpdatePartialAsync(
                    updateDto,
                    updateDto.OPTIONINDEX,
                    clientId
                );

                if (updateDto.ForcedChoices != null)
                {
                    var oldChoices = await _uow.ForceChoice.GetAllByQuestion(
                        clientId,
                        updateDto.OPTIONINDEX
                    );

                    var forceChoicesToInsert = new List<ForceChoice>();
                    var forceChoicesToUpdate = new List<ForceChoice>();
                    var forceChoicesToDelete = new List<ForceChoice>();

                    foreach (var oldChoice in oldChoices)
                    {
                        var incomingChoice = updateDto.ForcedChoices.FirstOrDefault(c =>
                            c.UNIQUEID == oldChoice.UNIQUEID
                        );

                        if (incomingChoice != null)
                            forceChoicesToUpdate.Add(incomingChoice);
                        else
                            forceChoicesToDelete.Add(oldChoice);
                    }

                    var newForceChoices = updateDto
                        .ForcedChoices.Where(c => c.UNIQUEID == 0)
                        .ToList();
                    if (newForceChoices.Count > 0)
                    {
                        var currentNextNumFromDb = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GETNEXT_ForceChoice,
                            clientId,
                            null,
                            newForceChoices.Count
                        );

                        int startSequence = currentNextNumFromDb - newForceChoices.Count + 1;

                        foreach (var newChoice in newForceChoices)
                        {
                            var choiceEntity = new ForceChoice
                            {
                                ClientId = clientId,
                                UNIQUEID = startSequence++,
                                OPTIONINDEX = updateDto.OPTIONINDEX,
                                CHOICE = newChoice.CHOICE,
                                PriceMode = newChoice.PriceMode,
                                FixedPrice = newChoice.FixedPrice,
                                Sequence = newChoice.Sequence,
                                IsActive = newChoice.IsActive,
                            };
                            forceChoicesToInsert.Add(choiceEntity);
                        }
                    }

                    if (forceChoicesToInsert.Count > 0)
                        await _uow.ForceChoice.AddRangeAsync(forceChoicesToInsert);

                    if (forceChoicesToUpdate.Count > 0)
                    {
                        foreach (var upd in forceChoicesToUpdate)
                        {
                            await _uow.ForceChoice.UpdatePartialAsync(upd, upd.UNIQUEID, clientId);
                        }
                    }

                    if (forceChoicesToDelete.Count > 0)
                    {
                        foreach (var del in forceChoicesToDelete)
                        {
                            await _uow.ForceChoice.UpdatePartialAsync(
                                new { ISACTIVE = (short)0 },
                                del.UNIQUEID,
                                clientId
                            );
                        }
                    }
                }

                _uow.Commit();

                return updatedQuestion;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
