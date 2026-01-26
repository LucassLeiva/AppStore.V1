namespace AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProduct
{
    public interface IUpdateProductOutputPort
    {
        int IdProduct { get; }
        Task Handle(Product updatedProduct);
    }
}
