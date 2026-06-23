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
    public class PromoReportCatRepository(IUnitOfWork _uow)
        : GenericRepository<PromoReportCat>(_uow),
            IPromoReportCatRepository
    {
        public Task<IEnumerable<PromoReportCat>> GetByPromoNum(Guid clientId, int promoNum)
        {
            var sql = """
                SELECT * FROM "PromoReportCats"
                WHERE "ClientId" = @ClientId
                AND "PROMONUM" = @PromoNum
                AND "IsActive" = 1
                """;

            return _uow.Connection.QueryAsync<PromoReportCat>(
                sql,
                new { ClientId = clientId, PromoNum = promoNum }
            );
        }
    }
}
