using BackOffice.Entity;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class SecurityService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Security>> GetAll(Guid clientId)
        {
            return await _uow.Security.GetAllAsync(true, clientId);
        }

        public async Task<Security> Update(Guid clientId, SecurityUpdate security)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedSecurity = await _uow.Security.UpdatePartialAsync(
                    security,
                    security.SEC_NUM,
                    clientId
                );
                _uow.Commit();
                return updatedSecurity;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
