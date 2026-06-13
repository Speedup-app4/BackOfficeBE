using BackOffice.Entity.System;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class RevenueCenterRepository(IUnitOfWork _uow)
        : GenericRepository<RevenueCenter>(_uow),
            IRevenueCenterRepository { }
}
