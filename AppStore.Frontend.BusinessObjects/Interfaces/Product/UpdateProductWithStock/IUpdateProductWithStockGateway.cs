namespace AppStore.Frontend.BusinessObjects.Interfaces.Product.UpdateProductWithStock
{
    public interface IUpdateProductWithStockGateway
    {
       
            Task<int> UpdateProductWithStockAsync(UpdateProductWithStockDto product);
    }
}
