namespace AppStore.Backend.Presenters.Products.ActivateProduct
{
    internal class ActivateProductPresenter : IActivateProductOutputPort
    {
        public int IdProduct { get; private set; }

        public Task Handle(int idProduct)
        {
            IdProduct = idProduct;
            return Task.CompletedTask;
        }
    }
}
