namespace AppStore.Backend.Presenters.Products.UpdateProductWithStock
{
    internal class UpdateProductWithStockPresenter
        : IUpdateProductWithStockOutputPort
    {
        public int IdProduct { get; private set; }


        public Task Handle(Product updatedProduct)
        {
            IdProduct = updatedProduct.IdProduct;

            return Task.CompletedTask;
        }
    }
}
