using BackOffice.Entity.Station;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class FormTemplateService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<FormTemplate>> GetAll(Guid clientId)
        {
            return await _uow.FormTemplate.GetAllAsync(true, clientId);
        }
    }
}
