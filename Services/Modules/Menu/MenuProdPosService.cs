using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOffice.Entity.Menu;
using BackOffice.Entity.Products;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services.Modules.Menu
{
    public class MenuProdPosService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<MenuProdPos>> Get(
            Guid clientId,
            int? orderCat = null,
            bool? isGetProduct = false
        )
        {
            List<MenuProdPos> menuProdPos = [];
            if (orderCat.HasValue)
                menuProdPos = [.. await _uow.MenuProdPos.GetByOrderCat(orderCat.Value, clientId)];
            else
                menuProdPos = [.. await _uow.MenuProdPos.GetAllAsync(true, clientId)];

            List<Product> products = [];

            if (isGetProduct == true)
            {
                var productIds = menuProdPos.Select(mpp => mpp.PRODNUM).Distinct();
                products = [.. await _uow.Product.GetByIdsAsync(productIds, true, clientId)];
            }

            var joinData = menuProdPos.Select(m =>
                m.ProductData = products.FirstOrDefault(p => p.PRODNUM == m.PRODNUM)
            );

            return menuProdPos;
        }
    }
}
