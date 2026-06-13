using BackOffice.Entity;
using BackOffice.Entity.Product;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
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
