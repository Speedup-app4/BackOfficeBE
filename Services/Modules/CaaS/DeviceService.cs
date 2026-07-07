using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.CaaS;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.CaaS
{
    public class DeviceService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Device>> GetAll(Guid clientId)
        {
            return await _uow.Device.GetAllAsync(true, clientId);
        }
    }
}
