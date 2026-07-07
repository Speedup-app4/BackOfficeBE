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
            return await _uow.Device.GetAllAsync(clientId);
        }

        public async Task<Device> Update(Guid clientId, DeviceUpdate device)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedDevice = await _uow.Device.UpdatePartialAsync(
                    device,
                    device.DeviceId,
                    clientId
                );
                _uow.Commit();
                return updatedDevice;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
