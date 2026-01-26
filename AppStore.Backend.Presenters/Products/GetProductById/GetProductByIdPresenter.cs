namespace AppStore.Backend.Presenters.Products.GetProductById
{
    internal class GetProductByIdPresenter : IGetProductByIdOutputPort
    {
        public ProductDetailsDto? Product { get; private set; }

        public Task Handle(ProductDetailsDto? product)
        {
            Product = product;
            return Task.CompletedTask;
        }
    }
}
