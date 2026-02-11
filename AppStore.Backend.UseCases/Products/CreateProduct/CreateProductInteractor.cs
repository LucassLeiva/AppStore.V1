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
            // 1) Validar modelo
            await GuardModel.AgainstNotValid(modelValidatorHub, dto);

            // 2) Crear dominio
            var stock = new Stock(dto.StockInicial);

            var product = new Product(
                dto.IdCategory,
                dto.InternalCode,
                dto.Name,
                dto.Price,
                                // 👈 no lo usamos para persistir ahora
                dto.IdSupplier,
                dto.Description
            );

            // 3) Trackear cambios (sin commitear)
            await repository.CreateProductWithInitialStock(product, stock);

            // ✅ 4) Un solo commit
            await repository.SaveChanges();

            // ✅ 5) Ahora product.IdProduct y stock.IdStock ya están
            await outputPort.Handle(product);
        }
    }

}
