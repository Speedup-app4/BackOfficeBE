using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Entity.Table;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Table
{
    public class TableSetupService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<TableSetup>> GetAll(Guid ClientId) =>
            await _uow.TableSetup.GetAllAsync(ClientId, true);

        public async Task<TableSetup> Create(Guid ClientId, TableSetup entity)
        {
            try
            {
                _uow.BeginTransaction();
                entity.ClientId = ClientId;
                var res = await _uow.TableSetup.AddAsync(entity);
                _uow.Commit();
                return res;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<TableSetup> Update(Guid ClientId, TableSetupUpdate entityUpdate)
        {
            try
            {
                _uow.BeginTransaction();
                var entity = await _uow.TableSetup.UpdatePartialAsync(
                    entityUpdate,
                    entityUpdate.TABLENUM,
                    ClientId
                );
                _uow.Commit();
                return entity;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<bool> Delete(Guid ClientId, int tablenum)
        {
            try
            {
                _uow.BeginTransaction();
                var entity = await _uow.TableSetup.GetByIdAsync(tablenum, ClientId, true);
                if (entity != null)
                {
                    await _uow.TableSetup.DeleteAsync(entity);
                    _uow.Commit();
                    return true;
                }
                return false;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
