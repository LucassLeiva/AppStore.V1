using AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProduct;
using AppStore.Entities.DTOs.Products.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.UseCases.Products.UpdateProduct
{
    internal class UpdateProductInteractor(
       IUpdateProductOutputPort outputPort,
       ICommandsRepository commands,
       IQueriesRepository queries) : IUpdateProductInputPort
    {
        public async Task Handle(UpdateProductDto dto)
        {
            // 1) Obtener el IdStock actual (para no tocar stock en este caso de uso)
            int stockId = await queries.GetStockIdByProductId(dto.IdProduct);

            // 2) Construir el producto con los nuevos datos (dominio valida invariantes)
            var product = new Product(
                dto.IdCategory,
                dto.InternalCode,
                dto.Name,
                dto.Price,
                stockId,
                dto.IdSupplier,
                dto.Description
            )
            {
                IdProduct = dto.IdProduct
            };

            // 3) Persistir cambios
            await commands.UpdateProduct(product);

            // 4) Respuesta
            await outputPort.Handle(product);
        }
    }
}
