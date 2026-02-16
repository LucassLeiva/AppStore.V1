namespace AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProductWithStock
{
    public interface IUpdateProductWithStockOutputPort
    {
        int IdProduct { get; } 
        Task Handle(Product updatedProduct);
    }
}
