using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.System
{
    public class FormTemplateService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<FormTemplate>> GetAll(Guid clientId)
        {
            return await _uow.FormTemplate.GetAllAsync(true, clientId);
        }
    }
}
