using AppStore.Entities.DTOs.Products.CreateProduct;

namespace AppStore.Backend.BusinessObjects.Interfaces.CreateProduct
{
    public interface ICreateProductInputPort
    {
        Task Handle(CreateProductDto orderDto);
    }
}
