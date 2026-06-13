using BackOffice.Entity.System;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class SysInfoRepository(IUnitOfWork _uow)
        : GenericRepository<SysInfo>(_uow),
            ISysInfoRepository { }
}
