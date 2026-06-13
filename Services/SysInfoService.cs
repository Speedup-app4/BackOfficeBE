using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class SysInfoService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<SysInfo>> GetAllSysInfosAsync(Guid clientId)
        {
            return await _uow.SysInfo.GetAllAsync(true, clientId);
        }
    }
}
