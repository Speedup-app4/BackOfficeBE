using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Report;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Report
{
    public class ReportTypeService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<ReportType>> GetAll(Guid clientId)
        {
            return await _uow.ReportType.GetAllAsync(clientId, true);
        }

        public async Task<IEnumerable<ReportType>> Update(
            Guid clientId,
            IEnumerable<ReportTypeUpdate> reportTypes
        )
        {
            try
            {
                _uow.BeginTransaction();
                var updatedReportTypes = new List<ReportType>();
                var updatedReportType = await _uow.ReportType.UpdatePartialRangeAsync(
                    reportTypes,
                    clientId
                );
                _uow.Commit();
                return await _uow.ReportType.GetAllAsync(clientId, true);
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
