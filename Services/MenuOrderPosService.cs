using BackOffice.Entity.Menu;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class MenuOrderPosService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<MenuOrderPos>> Get(
            Guid clientId,
            int? menuIndex = null,
            bool? isGetOrderCat = false
        )
        {
            List<MenuOrderPos> menuOrderPos;
            if (menuIndex.HasValue)
                menuOrderPos =
                [
                    .. await _uow.MenuOrderPos.GetByMenuIndex(menuIndex.Value, clientId),
                ];
            else
                menuOrderPos = [.. await _uow.MenuOrderPos.GetAllAsync(true, clientId)];

            List<OrderCat> orderCats = [];

            if (isGetOrderCat == true)
            {
                var orderCatIds = menuOrderPos.Select(mop => mop.ORDERCAT).Distinct();
                orderCats = [.. await _uow.OrderCat.GetByIdsAsync(orderCatIds, true, clientId)];
            }

            var joinData = menuOrderPos.Select(m =>
                m.OrderCatData = orderCats.FirstOrDefault(oc => oc.ORDERCAT == m.ORDERCAT)
            );

            return menuOrderPos;
        }
    }
}
