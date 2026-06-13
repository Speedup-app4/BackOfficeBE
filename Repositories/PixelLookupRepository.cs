using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class PixelLookupRepository(IUnitOfWork _uow)
        : GenericRepository<PixelLookup>(_uow),
            IPixelLookupRepository { }
}
