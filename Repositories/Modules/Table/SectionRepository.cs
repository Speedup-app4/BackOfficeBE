using BackOffice.Entity.Table;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Table;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Table
{
    public class SectionRepository(IUnitOfWork _uow)
        : GenericRepository<Section>(_uow),
            ISectionRepository { }
}
