using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.System
{
    public class PrintPortService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PrintPort>> GetAll(Guid clientId)
        {
            return await _uow.PrintPort.GetAllAsync(true, clientId);
        }
    }
}
