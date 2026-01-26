
using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.DataContexts.EFCore.Services
{
    
        internal class AppStoreCommandsDataContext(
            IOptions<DBOptions> dbOptions)
            : AppStoreProductionContext(dbOptions),
              IAppStoreCommandsDataContext
        {

            

            public async Task<StockEntity?> FindStockByIdAsync(int idStock) => await Stock.FindAsync(idStock);
            public async Task AddSupplierAsync(SupplierEntity supplier) => await AddAsync(supplier);
            public async Task AddCategoryAsync(CategoryEntity category) => await AddAsync(category);

            
            public async Task AddStockAsync(StockEntity stock) => await AddAsync(stock);


            //Product Commands
            public async Task AddProductAsync(ProductEntity product) => await AddAsync(product);
            public async Task<ProductEntity?> FindProductByIdAsync(int idProduct) => await Product.FindAsync(idProduct);
            public Task UpdateProductAsync(ProductEntity product)
            {
                Product.Update(product);
                return Task.CompletedTask;
            }

            public async Task SoftDeleteProductAsync(int idProduct)
            {
                var entity = await FindProductByIdAsync(idProduct);
                entity!.State = 0;
             }


        public async Task SaveChangesAsync() => await base.SaveChangesAsync();



        }
}


