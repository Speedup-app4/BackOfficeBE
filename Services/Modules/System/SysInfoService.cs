using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.System
{
    public class SysInfoService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<SysInfo>> GetAllSysInfosAsync(Guid clientId)
        {
            return await _uow.SysInfo.GetAllAsync(true, clientId);
        }
    }
}
