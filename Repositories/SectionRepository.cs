using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class SectionRepository(IUnitOfWork _uow)
        : GenericRepository<Section>(_uow),
            ISectionRepository { }
}
