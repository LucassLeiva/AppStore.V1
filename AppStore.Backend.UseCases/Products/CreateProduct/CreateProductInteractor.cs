using AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct;

namespace AppStore.Backend.UseCases.Products.CreateProduct
{
    internal class CreateProductInteractor(
    ICreateProductOutputPort outputPort,
    ICommandsRepository repository,
    IModelValidatorHub<CreateProductDto> modelValidatorHub) : ICreateProductInputPort
    {
        public async Task Handle(CreateProductDto dto)
        {
            //Validar modelo
            await GuardModel.AgainstNotValid(modelValidatorHub, dto);

            // Crear stock con la cantidad inicial (DTO trae short)
            var stock = new Stock(dto.StockInicial);

            //Persistir stock y obtener su Id generado por DB
            int stockId = await repository.CreateStock(stock);
            stock.IdStock = stockId; // opcional, por claridad

            //Crear producto apuntando al stockId real
            var product = new Product(
                dto.IdCategory,
                dto.InternalCode,
                dto.Name,
                dto.Price,
                stockId,
                dto.IdSupplier,
                dto.Description
            );

            //Persistir producto y obtener IdProducto real
            int productId = await repository.CreateProduct(product);
            product.IdProduct = productId;

            //Presenter ya recibe IdProducto correcto
            await outputPort.Handle(product);
        }
    }

}
