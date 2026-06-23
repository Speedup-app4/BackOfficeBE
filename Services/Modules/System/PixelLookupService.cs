using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.System
{
    public class PixelLookupService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PixelLookup>> GetAll(Guid clientId)
        {
            return await _uow.PixelLookup.GetAllAsync(true, clientId);
        }
    }
}
