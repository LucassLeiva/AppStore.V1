namespace AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct
{
    public interface ICreateProductOutputPort
    {
        int IdProduct { get; }
        Task Handle(Product addedProduct);
    }
}
