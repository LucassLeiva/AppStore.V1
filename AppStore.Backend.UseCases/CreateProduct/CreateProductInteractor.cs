using AppStore.Entities.DTOs.Products.CreateProduct;

namespace AppStore.Backend.UseCases.CreateProduct
{
    internal class CreateProductInteractor(
    ICreateProductOutputPort outputPort,
    ICommandsRepository repository) : ICreateProductInputPort
    {
        public async Task Handle(CreateProductDto dto)
        {
            // 1) Crear stock con la cantidad inicial (DTO trae short)
            var stock = new Stock((int)dto.StockInicial);

            // 2) Persistir stock y obtener su Id generado por DB
            int stockId = await repository.CreateStock(stock);
            stock.IdStock = stockId; // opcional, por claridad

            // 3) Crear producto apuntando al stockId real
            var product = new Product(
                dto.IdCategory,
                dto.InternalCode,
                dto.Name,
                dto.Price,
                stockId,
                dto.IdSupplier,
                dto.Description
            );

            // 4) Persistir producto y obtener IdProducto real
            int productId = await repository.CreateProduct(product);
            product.IdProduct = productId;

            // 5) Presenter ya recibe IdProducto correcto
            await outputPort.Handle(product);
        }
    }

    }
