using BackOffice.Entity.Product;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class ProductComboService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<ProductCombo>> GetAll(Guid clientId)
        {
            return await _uow.ProductCombo.GetAllAsync(true, clientId);
        }

        public async Task<ProductCombo> Create(Guid clientId, ProductCombo productCombo)
        {
            try
            {
                _uow.BeginTransaction();
                var ProductComboID = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GetNext_ProductComboID,
                    clientId
                );
                productCombo.ProductComboID = ProductComboID;
                productCombo.ClientId = clientId;

                var createdProductCombo = await _uow.ProductCombo.AddAsync(productCombo);
                _uow.Commit();
                return createdProductCombo;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<ProductCombo> Update(Guid clientId, ProductComboUpdate productCombo)
        {
            try
            {
                _uow.BeginTransaction();
                var updatedProductCombo = await _uow.ProductCombo.UpdatePartialAsync(
                    productCombo,
                    productCombo.ProductComboID,
                    clientId
                );
                _uow.Commit();
                return updatedProductCombo;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
