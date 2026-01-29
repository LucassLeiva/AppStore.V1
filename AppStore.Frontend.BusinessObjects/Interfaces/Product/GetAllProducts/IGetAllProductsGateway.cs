namespace AppStore.Frontend.BusinessObjects.Interfaces.Product.GetAllProducts
{
    public interface IGetAllProductsGateway
    {
        Task<IEnumerable<ProductItemDto>> GetAllAsync(bool includeInactive);
    }
}
