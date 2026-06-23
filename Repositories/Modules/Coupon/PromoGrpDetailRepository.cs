using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Coupon;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Coupon;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.Coupon
{
    public class PromoGrpDetailRepository(IUnitOfWork _uow)
        : GenericRepository<PromoGrpDetail>(_uow),
            IPromoGrpDetailRepository
    {
        public Task<IEnumerable<PromoGrpDetail>> GetByGrpId(Guid clientId, int promoGrpId)
        {
            var sql =
                @"SELECT * FROM ""PromoGrpDetail"" WHERE ""ClientId"" = @clientId AND ""PromoGrpID"" = @promoGrpId";
            return _uow.Connection.QueryAsync<PromoGrpDetail>(sql, new { clientId, promoGrpId });
        }
    }
}
