namespace AppStore.Backend.Presenters.Products.UpdateProduct
{
    internal class UpdateProductPresenter : IUpdateProductOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(Product updatedProduct)
        {
            IdProduct = updatedProduct.IdProduct;
            return Task.CompletedTask;
        }
    }
}
