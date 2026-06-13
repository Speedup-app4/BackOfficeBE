using BackOffice.Entity;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class PixelLookupService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PixelLookup>> GetAll(Guid clientId)
        {
            return await _uow.PixelLookup.GetAllAsync(true, clientId);
        }
    }
}
