using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.System
{
    public class RevenueCenterRepository(IUnitOfWork _uow)
        : GenericRepository<RevenueCenter>(_uow),
            IRevenueCenterRepository { }
}
