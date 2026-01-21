namespace AppStore.Frontend.BusinessObjects.Interfaces
{
    public interface ICreateProductGateway
    {
        Task<int> CreateProductAsync(CreateProductDto order);
    }
}
