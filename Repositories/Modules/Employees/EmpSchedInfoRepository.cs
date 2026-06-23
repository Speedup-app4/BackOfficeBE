using System;
using System.Threading.Tasks;
using BackOffice.Entity.Employees;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.Employees;
using BackOffice.Repositories.Base;
using Dapper;

namespace BackOffice.Repositories.Modules.Employees
{
    public class EmpSchedInfoRepository(IUnitOfWork _uow)
        : GenericRepository<EmpSchedInfo>(_uow),
            IEmpSchedInfoRepository
    {
        public Task<EmpSchedInfo?> GetByEmpNum(Guid clientId, int empNum)
        {
            var sql = @"SELECT * FROM EmpSchedInfo WHERE ClientId = @ClientId AND EmpNum = @EmpNum";
            return _uow.Connection.QueryFirstOrDefaultAsync<EmpSchedInfo>(
                sql,
                new { ClientId = clientId, EmpNum = empNum }
            );
        }
    }
}
