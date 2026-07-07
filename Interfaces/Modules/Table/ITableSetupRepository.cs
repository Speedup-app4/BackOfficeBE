using BackOffice.Entity.Table;
using BackOffice.Interfaces.Base;

namespace BackOffice.Interfaces.Modules.Table
{
    public interface ITableSetupRepository
        : IReadRepository<TableSetup>,
            IWriteRepository<TableSetup> { }
}
