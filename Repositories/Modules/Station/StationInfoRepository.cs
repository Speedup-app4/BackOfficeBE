using BackOffice.Entity.Station;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Station;
using BackOffice.Repositories.Base;

namespace BackOffice.Repositories.Modules.Station
{
    public class StationInfoRepository(IUnitOfWork _uow)
        : GenericRepository<StationInfo>(_uow),
            IStationInfoRepository { }
}
