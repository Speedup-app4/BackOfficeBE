using BackOffice.Entity.Report;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class ReportTypeService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<ReportType>> GetAll(Guid clientId)
        {
            return await _uow.ReportType.GetAllAsync(true, clientId);
        }
    }
}
