using BackOffice.Entity.Products;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class QuestionRepository(IUnitOfWork _uow)
        : GenericRepository<Question>(_uow),
            IQuestionRepository { }
}
