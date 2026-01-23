namespace AppStore.Backend.BusinessObjects.Interfaces.CreateProduct
{
    public interface ICreateProductOutputPort
    {
        int IdProduct { get; }
        Task Handle(Product addedProduct);
    }
}
