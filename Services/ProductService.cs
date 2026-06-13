using BackOffice.Entity.Product;
using BackOffice.Interfaces;
using BackOffice.Interfaces.Base;

namespace BackOffice.Services
{
    public class ProductService(IUnitOfWork _uow)
    {
        public async Task<IEnumerable<Product>> Get(Guid clientId, int? ProdNum = null)
        {
            var productList = new List<Product>();
            var productComboList = new List<ProductCombo>();
            if (ProdNum.HasValue)
            {
                var product =
                    await _uow.Product.GetByIdAsync(ProdNum.Value, true, clientId)
                    ?? throw new Exception("Không tìm thấy sản phẩm");
                productList.Add(product);

                var productCombos = await _uow.ProductCombo.GetAllByProdLinkNum(
                    clientId,
                    ProdNum.Value
                );
                productComboList.AddRange(productCombos);
            }
            else
            {
                var products = await _uow.Product.GetAllAsync(true, clientId);
                productList.AddRange(products);
                var productCombos = await _uow.ProductCombo.GetAllAsync(true, clientId);
                productComboList.AddRange(productCombos);
            }

            var joinData = productList.Select(p =>
            {
                p.ProductCombos = [.. productComboList.Where(pc => pc.ProdLinkNum == p.PRODNUM)];
                return p;
            });

            return joinData;
        }

        public async Task<Product> Create(Guid clientId, Product product)
        {
            try
            {
                _uow.BeginTransaction();
                var PRODUCTNUM = await _uow.AutoInc.GetNextSequenceAsync(
                    AutoIncType.GETNEXT_PRODUCT,
                    clientId
                );
                product.PRODNUM = PRODUCTNUM;
                product.ClientId = clientId;

                List<ProductCombo> productCombos = [];

                if (product.ProductCombos != null && product.ProductCombos.Count() > 0)
                {
                    var nextSequence = await _uow.AutoInc.GetNextSequenceAsync(
                        AutoIncType.GetNext_ProductComboID,
                        clientId,
                        null,
                        product.ProductCombos.Count()
                    );

                    int startSequence = nextSequence - product.ProductCombos.Count() + 1;

                    foreach (var combo in product.ProductCombos)
                    {
                        combo.ProductComboID = startSequence++;
                        combo.ProdLinkNum = PRODUCTNUM;
                        combo.ClientId = clientId;
                        productCombos.Add(combo);
                    }
                }

                var createdProduct = await _uow.Product.AddAsync(product);

                if (productCombos.Count > 0)
                {
                    await _uow.ProductCombo.AddRangeAsync(productCombos);
                    createdProduct.ProductCombos = productCombos;
                }

                _uow.Commit();
                return createdProduct;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }

        public async Task<Product> Update(Guid clientId, ProductUpdate updateDto)
        {
            try
            {
                _uow.BeginTransaction();

                var updatedProduct = await _uow.Product.UpdatePartialAsync(
                    updateDto,
                    updateDto.PRODNUM,
                    clientId
                );

                if (updateDto.ProductCombos != null)
                {
                    var oldCombos = await _uow.ProductCombo.GetAllByProdLinkNum(
                        clientId,
                        updateDto.PRODNUM
                    );

                    var combosToInsert = new List<ProductCombo>();
                    var combosToUpdate = new List<ProductCombo>();
                    var combosToDelete = new List<ProductCombo>();

                    foreach (var oldCombo in oldCombos)
                    {
                        var incomingCombo = updateDto.ProductCombos.FirstOrDefault(c =>
                            c.ProductComboID == oldCombo.ProductComboID
                        );

                        if (incomingCombo != null)
                            combosToUpdate.Add(incomingCombo);
                        else
                            combosToDelete.Add(oldCombo);
                    }

                    var newCombos = updateDto
                        .ProductCombos.Where(c => c.ProductComboID == 0)
                        .ToList();
                    if (newCombos.Count > 0)
                    {
                        var currentNextNumFromDb = await _uow.AutoInc.GetNextSequenceAsync(
                            AutoIncType.GetNext_ProductComboID,
                            clientId,
                            null,
                            newCombos.Count
                        );

                        int startSequence = currentNextNumFromDb - newCombos.Count + 1;

                        foreach (var newCombo in newCombos)
                        {
                            var comboEntity = new ProductCombo
                            {
                                ClientId = clientId,
                                ProductComboID = startSequence++,
                                ProdLinkNum = updateDto.PRODNUM,
                                ReqItem = newCombo.Sequence,
                                PriceMode = newCombo.PriceMode,
                                FixedPrice = newCombo.FixedPrice,
                                Sequence = newCombo.Sequence,
                                ProdNum = newCombo.ProdNum,
                                IsActive = 1,
                            };
                            combosToInsert.Add(comboEntity);
                        }
                    }

                    if (combosToInsert.Count > 0)
                        await _uow.ProductCombo.AddRangeAsync(combosToInsert);

                    if (combosToUpdate.Count > 0)
                    {
                        foreach (var upd in combosToUpdate)
                        {
                            await _uow.ProductCombo.UpdatePartialAsync(
                                upd,
                                upd.ProductComboID,
                                clientId
                            );
                        }
                    }

                    if (combosToDelete.Count > 0)
                    {
                        foreach (var del in combosToDelete)
                        {
                            await _uow.ProductCombo.UpdatePartialAsync(
                                new { IsActive = (short)0 },
                                del.ProductComboID,
                                clientId
                            );
                        }
                    }
                }

                _uow.Commit();

                return updatedProduct;
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}
