using AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct;

namespace AppStore.Backend.Presenters.Products.CreateProduct
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
