using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class SummaryGroupService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<SummaryGroup>> GetAll(Guid clientId)
        {
            return await _uow.SummaryGroups.GetAllAsync(true, clientId);
        }

        public async Task<SummaryGroup> Create(Guid clientId, SummaryGroup summaryGroup)
        {
            try
            {
                _uow.BeginTransaction();
                var SUMMARYNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_SUMMARYGROUP,
                    clientId
                );

                summaryGroup.SUMMARYNUM = SUMMARYNUM;
                summaryGroup.ClientId = clientId;

                var createdSummaryGroup = await _uow.SummaryGroups.AddAsync(summaryGroup);
                _uow.Commit();
                return createdSummaryGroup;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<SummaryGroup> Update(Guid clientId, SummaryGroupUpdate summaryGroup)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedSummaryGroup = await _uow.SummaryGroups.UpdatePartialAsync(
                    summaryGroup,
                    summaryGroup.SUMMARYNUM,
                    clientId
                );
                _uow.Commit();
                return updatedSummaryGroup;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
