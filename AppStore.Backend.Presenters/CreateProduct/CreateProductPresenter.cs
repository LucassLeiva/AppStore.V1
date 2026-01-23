namespace AppStore.Backend.Presenters.CreateProduct
{
    internal class CreateProductPresenter : ICreateProductOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(Product addedProduct)
        {
            IdProduct = addedProduct.IdProduct;
            return Task.CompletedTask;
        }
    }

}
