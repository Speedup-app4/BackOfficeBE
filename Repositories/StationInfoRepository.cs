using BackOffice.Entity.Station;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories
{
    public class StationInfoRepository(IUnitOfWork _uow)
        : GenericRepository<StationInfo>(_uow),
            IStationInfoRepository { }
}
