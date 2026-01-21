
namespace AppStore.Backend.DataContexts.EFCore.Services
{
    
        internal class AppStoreCommandsDataContext(
            IOptions<DBOptions> dbOptions)
            : AppStoreProductionContext(dbOptions),
              IAppStoreCommandsDataContext
        {

        public async Task AddSupplierAsync(SupplierEntity supplier) =>
            await AddAsync(supplier);
        public async Task AddCategoryAsync(CategoryEntity category) =>
            await AddAsync(category);

             public async Task AddProductAsync(ProductEntity product) =>
               await AddAsync(product);
             public async Task AddStockAsync(StockEntity stock) =>
                await AddAsync(stock);

            public async Task SaveChangesAsync() =>
                await base.SaveChangesAsync();
        }
}


