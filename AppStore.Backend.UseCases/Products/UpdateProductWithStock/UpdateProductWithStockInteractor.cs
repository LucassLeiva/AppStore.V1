namespace AppStore.Backend.UseCases.Products.UpdateProductWithStock
{
    internal class UpdateProductWithStockInteractor(
        IUpdateProductWithStockOutputPort outputPort,
        ICommandsRepository commands,
        IQueriesRepository queries,
        IModelValidatorHub<UpdateProductWithStockDto> modelValidatorHub,
        IDomainTransaction domainTransaction
    ) : IUpdateProductWithStockInputPort
    {
        public async Task Handle(UpdateProductWithStockDto dto)
        {
            // 0) Validación del DTO completo
            await GuardModel.AgainstNotValid(modelValidatorHub, dto);

            // 1) Necesitamos el IdStock del producto para poder actualizar la tabla Stock
            int stockId = await queries.GetStockIdByProductId(dto.IdProduct);

            // 2) Armar dominio Product con nuevos datos (valida invariantes)
            var product = new Product(
                dto.IdCategory,
                dto.InternalCode,
                dto.Name,
                dto.Price,
                dto.IdSupplier,
                dto.Description
            )
            {
                IdProduct = dto.IdProduct
            };

            // mantenemos la regla de dominio: el producto tiene FK al stock
            product.AttachStock(stockId);

            try
            {
                // 3) Transacción: producto + stock como una sola unidad
                domainTransaction.BeginTransaction();

                // 3.1) Update Product (tabla Products)
                await commands.UpdateProduct(product);

                // 3.2) Update Stock (tabla Stocks)
                await commands.UpdateStockAmount(stockId, dto.StockAmount);

                // si tu arquitectura usa SaveChanges centralizado en UnitOfWork:
                await commands.SaveChanges();

                domainTransaction.CommitTransaction();

                //Outputport fuera, porque es buena practica dar prioridad a “Persistencia/transacción" y posteriormente a “Presentación/respuesta”
                //Asegurandonos asi que la base de datos va a quedar consistente por mas que despues falle al armarse la respuesta a la UI.
                await outputPort.Handle(product);
            }
            catch
            {
                domainTransaction.RollbackTransaction();
                throw;
            }
        }
    }
}
