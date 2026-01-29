namespace AppStore.Backend.Repositories.Interfaces
{
    public interface IAppStoreCommandsDataContext
    {
        //Products
        Task AddProductAsync(ProductEntity product);
        Task<ProductEntity?> FindProductByIdAsync(int idProduct);
        Task UpdateProductAsync(ProductEntity product);
        Task SoftDeleteProductAsync(int idProduct);

        


        //Stocks
        Task AddStockAsync(StockEntity stock);
        
        Task<StockEntity?> FindStockByIdAsync(int idStock);


        //Categories
        Task AddCategoryAsync(CategoryEntity entity);
        Task UpdateCategoryAsync(CategoryEntity category);
        Task<CategoryEntity?> FindCategoryByIdAsync(int idCategory);
        Task SoftDeleteCategoryAsync(int idCategory);

        //Suppliers
        Task AddSupplierAsync(SupplierEntity supplier);
        Task UpdateSupplierAsync(SupplierEntity supplier);
        Task<SupplierEntity?> FindSupplierByIdAsync(int idSupplier);
        Task SoftDeleteSupplierAsync(int idSupplier);
        





        Task SaveChangesAsync();
        
    }
}
