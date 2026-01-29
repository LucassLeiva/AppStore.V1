namespace AppStore.Backend.BusinessObjects.Interfaces.Products.GetAllProducts
{
    public interface IGetAllProductsOutputPort
    {
        IEnumerable<ProductItemDto> Products { get; }
        Task Handle(IEnumerable<ProductItemDto> products);
    }
}
