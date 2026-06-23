using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Employees;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.Employees
{
    public class PayRollRepository(IUnitOfWork _uow)
        : GenericRepository<PayRoll>(_uow),
            IPayRollRepository
    {
        public async Task<IEnumerable<PayRoll>> GetByEmpNum(Guid clientId, int empNum)
        {
            var sql =
                @"SELECT * FROM ""PayRoll""  WHERE ""EMPNUM"" = @EmpNum AND ""ClientId"" = @ClientId";
            var parameters = new { EmpNum = empNum, ClientId = clientId };
            return await _uow.Connection.QueryAsync<PayRoll>(sql, parameters, _uow.Transaction);
        }
    }
}
