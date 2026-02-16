using AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct;
using AppStore.Transactions.Entities.Interfaces;
using AppStore.Validation.Entities.Interfaces;

namespace AppStore.Backend.UseCases.Products.CreateProduct
{
    internal class CreateProductInteractor(
    ICreateProductOutputPort outputPort,
    ICommandsRepository repository,
    IModelValidatorHub<CreateProductDto> modelValidatorHub,
    IDomainTransaction domainTransaction) : ICreateProductInputPort
    {

        public async Task Handle(CreateProductDto dto)
        {
            await GuardModel.AgainstNotValid(modelValidatorHub, dto);

            var stock = new Stock(dto.StockInicial);

            var product = new Product(
                dto.IdCategory,
                dto.InternalCode,
                dto.Name,
                dto.Price,
                dto.IdSupplier,
                dto.Description
            );

            try
            {
                domainTransaction.BeginTransaction();

                var (idProduct, idStock) =
                    await repository.CreateProductWithInitialStock(product, stock);

                

                
                stock.IdStock = idStock;
                product.IdProduct = idProduct;

                // Verifica si cumple la regla para asignar el ID al private set
                product.AttachStock(idStock);

                await outputPort.Handle(product);

                domainTransaction.CommitTransaction();
            }
            catch
            {
                domainTransaction.RollbackTransaction();
                throw;
            }
        }
    }
}

