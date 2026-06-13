using BackOffice.Entity;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class PayMethReportCatService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PayMethReportCat>> GetAll(Guid clientId)
        {
            return await _uow.PayMethReportCat.GetAllAsync(true, clientId);
        }
    }
}
