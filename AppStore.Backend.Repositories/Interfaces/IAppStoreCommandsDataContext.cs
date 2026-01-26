namespace AppStore.Backend.Repositories.Interfaces
{
    public interface IAppStoreCommandsDataContext
    {
        //Products
        Task AddProductAsync(ProductEntity product);
        Task<ProductEntity?> FindProductByIdAsync(int idProduct);

        Task UpdateProductAsync(ProductEntity product);

        Task AddCategoryAsync(CategoryEntity category);
        Task AddSupplierAsync(SupplierEntity supplier);

        //Stocks
        Task AddStockAsync(StockEntity stock);
        
        Task<StockEntity?> FindStockByIdAsync(int idStock);


        Task SaveChangesAsync();
        Task SoftDeleteProductAsync(int idProduct);
    }
}
