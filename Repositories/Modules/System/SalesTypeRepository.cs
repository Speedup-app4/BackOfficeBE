using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.System
{
    public class SalesTypeRepository(IUnitOfWork _uow)
        : GenericRepository<SalesType>(_uow),
            ISalesTypeRepository { }
}
