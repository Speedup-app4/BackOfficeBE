using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class ShiftRuleRepository(IUnitOfWork _uow)
        : GenericRepository<ShiftRule>(_uow),
            IShiftRuleRepository { }
}
