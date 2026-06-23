using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Payment;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Payment
{
    public class PayMethReportCatService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<PayMethReportCat>> GetAll(Guid clientId)
        {
            return await _uow.PayMethReportCat.GetAllAsync(true, clientId);
        }
    }
}
