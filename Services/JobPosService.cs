using BackOffice.Entity.Employees;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class JobPosService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<JobPos>> GetAll(Guid clientId)
        {
            return await _uow.JobPos.GetAllAsync(true, clientId);
        }

        public async Task<JobPos> Create(Guid clientId, JobPos jobPos)
        {
            try
            {
                _uow.BeginTransaction();
                var JOBPOS = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_JOBPOS,
                    clientId
                );
                jobPos.JOBPOS = JOBPOS;
                jobPos.ClientId = clientId;

                var createdJobPos = await _uow.JobPos.AddAsync(jobPos);
                _uow.Commit();
                return createdJobPos;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<JobPos> Update(Guid clientId, JobPosUpdate jobPos)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedJobPos = await _uow.JobPos.UpdatePartialAsync(
                    jobPos,
                    jobPos.JOBPOS,
                    clientId
                );
                _uow.Commit();
                return updatedJobPos;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
