using BackOffice.Entity.Station;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class FormTemplateRepository(IUnitOfWork _uow)
        : GenericRepository<FormTemplate>(_uow),
            IFormTemplateRepository { }
}
