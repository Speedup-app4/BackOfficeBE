using BackOffice.Entity.System;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class PrintPortRepository(IUnitOfWork _uow)
        : GenericRepository<PrintPort>(_uow),
            IPrintPortRepository { }
}
