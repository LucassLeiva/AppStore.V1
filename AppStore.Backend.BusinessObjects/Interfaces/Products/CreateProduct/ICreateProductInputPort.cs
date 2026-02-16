using AppStore.Entities.DTOs.Products.CreateProduct;

namespace AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct
{
    public interface ICreateProductInputPort
    {
        Task Handle(CreateProductDto createProductDto);
    }
}
