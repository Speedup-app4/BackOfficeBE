using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Station;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Station
{
    public class StationInfoService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<StationInfo>> GetAll(Guid clientId)
        {
            return await _uow.StationInfo.GetAllAsync(true, clientId);
        }

        public async Task<StationInfo> Create(Guid clientId, StationInfo stationInfo)
        {
            try
            {
                _uow.BeginTransaction();
                var STATNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_STATNUM,
                    clientId
                );
                stationInfo.StatNum = STATNUM;

                var createdStationInfo = await _uow.StationInfo.AddAsync(stationInfo);
                _uow.Commit();
                return createdStationInfo;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<StationInfo> Update(Guid clientId, StationInfoUpdate stationInfo)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedStationInfo = await _uow.StationInfo.UpdatePartialAsync(
                    stationInfo,
                    stationInfo.StatNum,
                    clientId
                );
                _uow.Commit();
                return updatedStationInfo;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
