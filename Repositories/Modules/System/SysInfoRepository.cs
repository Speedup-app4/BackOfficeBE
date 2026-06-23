using BackOffice.Entity.System;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.System
{
    public class SysInfoRepository(IUnitOfWork _uow)
        : GenericRepository<SysInfo>(_uow),
            ISysInfoRepository { }
}
