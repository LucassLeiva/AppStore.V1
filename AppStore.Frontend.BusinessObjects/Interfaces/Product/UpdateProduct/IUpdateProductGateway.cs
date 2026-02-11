using AppStore.Entities.DTOs.Products.GetProducts;

namespace AppStore.Frontend.BusinessObjects.Interfaces.Product.UpdateProduct
{
    public interface IUpdateProductGateway
    {

        Task UpdateAsync(UpdateProductDto dto);
    }
}
