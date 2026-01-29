namespace AppStore.Backend.Presenters.Products.GetAllProducts
{
    internal class GetAllProductsPresenter : IGetAllProductsOutputPort
    {
        public IEnumerable<ProductItemDto> Products { get; private set; } = [];
        public Task Handle(IEnumerable<ProductItemDto> products)
        {
            Products = products;
            return Task.CompletedTask;
        }
    }
}
