using BackOffice.Entity.Report;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class ReportCatService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<ReportCat>> GetAll(Guid clientId)
        {
            return await _uow.ReportCat.GetAllAsync(true, clientId);
        }

        public async Task<ReportCat> Create(Guid clientId, ReportCat reportCat)
        {
            try
            {
                _uow.BeginTransaction();
                var REPORTNO = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_REPORTCAT,
                    clientId
                );
                reportCat.REPORTNO = REPORTNO;
                reportCat.ClientId = clientId;

                var createdReportCat = await _uow.ReportCat.AddAsync(reportCat);
                _uow.Commit();
                return createdReportCat;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<ReportCat> Update(Guid clientId, ReportCatUpdate reportCat)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedReportCat = await _uow.ReportCat.UpdatePartialAsync(
                    reportCat,
                    reportCat.REPORTNO,
                    clientId
                );
                _uow.Commit();
                return updatedReportCat;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
