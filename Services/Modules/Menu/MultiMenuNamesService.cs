using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;
using BackOffice.Interfaces.Modules.System;

namespace BackOffice.Services.Modules.Menu
{
    public class MultiMenuNameService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<MultiMenuName>> GetAll(Guid clientId)
        {
            return await _uow.MultiMenuName.GetAllAsync(true, clientId);
        }

        public async Task<MultiMenuName> Create(Guid clientId, MultiMenuName multiMenuName)
        {
            try
            {
                _uow.BeginTransaction();
                var MENUINDEX = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_MENUNAMES,
                    clientId
                );
                multiMenuName.MENUINDEX = MENUINDEX;
                multiMenuName.ClientId = clientId;

                var createdMultiMenuName = await _uow.MultiMenuName.AddAsync(multiMenuName);
                _uow.Commit();
                return createdMultiMenuName;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<MultiMenuName> Update(Guid clientId, MultiMenuNameUpdate multiMenuName)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedMultiMenuName = await _uow.MultiMenuName.UpdatePartialAsync(
                    multiMenuName,
                    multiMenuName.MENUINDEX,
                    clientId
                );
                _uow.Commit();
                return updatedMultiMenuName;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<MenuSetup> UpdateMenu(Guid clientId, MenuSetup menuSetup)
        {
            bool hasProdPos =
                menuSetup.ListMenuProdPos != null && menuSetup.ListMenuProdPos.Count > 0;
            bool hasOrderPos =
                menuSetup.ListMenuOrderPos != null && menuSetup.ListMenuOrderPos.Count > 0;

            if (!hasProdPos && !hasOrderPos)
                throw new Exception("Data cannot be empty!");

            try
            {
                _uow.BeginTransaction();

                var createProdPosList = new List<MenuProdPos>();
                var updateProdPosList = new List<MenuProdPos>();

                var createOrderPosList = new List<MenuOrderPos>();
                var updateOrderPosList = new List<MenuOrderPos>();

                if (hasProdPos)
                {
                    var newItems = menuSetup.ListMenuProdPos!.Where(x => x.UniqueID <= 0).ToList();
                    updateProdPosList = [.. menuSetup.ListMenuProdPos!.Where(x => x.UniqueID > 0)];

                    if (newItems.Count > 0)
                    {
                        var nextNumDb = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GETNEXT_MenuProdPos,
                            clientId,
                            null,
                            newItems.Count
                        );
                        int startId = nextNumDb - newItems.Count + 1;

                        foreach (var item in newItems)
                        {
                            item.UniqueID = startId++;
                            item.ClientId = clientId;
                            item.ISACTIVE = 1;
                            createProdPosList.Add(item);
                        }
                    }
                }

                if (hasOrderPos)
                {
                    var newItems = menuSetup.ListMenuOrderPos!.Where(x => x.UNIQUEID <= 0).ToList();
                    updateOrderPosList =
                    [
                        .. menuSetup.ListMenuOrderPos!.Where(x => x.UNIQUEID > 0),
                    ];

                    if (newItems.Count > 0)
                    {
                        var nextNumDb = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GETNEXT_MenuOrderPos,
                            clientId,
                            null,
                            newItems.Count
                        );
                        int startId = nextNumDb - newItems.Count + 1;

                        foreach (var item in newItems)
                        {
                            item.UNIQUEID = startId++;
                            item.ClientId = clientId;
                            item.ISACTIVE = 1;
                            createOrderPosList.Add(item);
                        }
                    }
                }

                if (createProdPosList.Count > 0)
                    await _uow.MenuProdPos.AddRangeAsync(createProdPosList);

                if (createOrderPosList.Count > 0)
                    await _uow.MenuOrderPos.AddRangeAsync(createOrderPosList);

                if (updateProdPosList.Count > 0)
                {
                    foreach (var item in updateProdPosList)
                        item.ClientId = clientId;
                    await _uow.MenuProdPos.UpdatePartialRangeAsync(updateProdPosList, clientId);
                }

                if (updateOrderPosList.Count > 0)
                {
                    foreach (var item in updateOrderPosList)
                        item.ClientId = clientId;
                    await _uow.MenuOrderPos.UpdatePartialRangeAsync(updateOrderPosList, clientId);
                }

                _uow.Commit();

                return new MenuSetup
                {
                    ListMenuProdPos = createProdPosList.Concat(updateProdPosList).ToList(),
                    ListMenuOrderPos = createOrderPosList.Concat(updateOrderPosList).ToList(),
                };
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
