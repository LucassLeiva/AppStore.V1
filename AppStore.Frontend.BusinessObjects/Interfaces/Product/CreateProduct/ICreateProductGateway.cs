namespace AppStore.Frontend.BusinessObjects.Interfaces.Product.CreateProduct
{
    public interface ICreateProductGateway
    {
        Task<int> CreateProductAsync(CreateProductDto order);
    }
}
