namespace AppStore.Backend.Repositories.Interfaces
{
    public interface IAppStoreCommandsDataContext
    {
        Task AddProductAsync(ProductEntity product);
        Task AddStockAsync(StockEntity stock);
        Task AddCategoryAsync(CategoryEntity category);
        Task AddSupplierAsync(SupplierEntity supplier);
        Task SaveChangesAsync();
    }
}
