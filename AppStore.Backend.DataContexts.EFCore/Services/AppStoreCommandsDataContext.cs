using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.DataContexts.EFCore.Services
{

    internal class AppStoreCommandsDataContext(
            IOptions<DBOptions> dbOptions)
            : AppStoreProductionContext(dbOptions),
              IAppStoreCommandsDataContext
        {
      
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


            //Stock Commands
            public async Task AddStockAsync(StockEntity stock) => await AddAsync(stock);
            public async Task<StockEntity?> FindStockByIdAsync(int idStock) => await Stock.FindAsync(idStock);


            //Category Commands
            public async Task AddCategoryAsync(CategoryEntity category) => await AddAsync(category);

            public async Task<CategoryEntity?> FindCategoryByIdAsync(int idCategory) => await Category.FindAsync(idCategory);

            public Task UpdateCategoryAsync(CategoryEntity category)
            {
                Category.Update(category);
                return Task.CompletedTask;
            }

           public async Task SoftDeleteCategoryAsync(int idCategory)
            {
                var entity = await FindCategoryByIdAsync(idCategory);
                entity!.State = 0;
            }



            //Supplier Commands
            public async Task AddSupplierAsync(SupplierEntity supplier) => await AddAsync(supplier);

            public Task UpdateSupplierAsync(SupplierEntity supplier)
            {
                Supplier.Update(supplier);
                return Task.CompletedTask;
            }

            public async Task<SupplierEntity?> FindSupplierByIdAsync(int idSupplier)
            {
                return await Supplier.FindAsync(idSupplier);
            }

            public async Task SoftDeleteSupplierAsync(int idSupplier)
            {
                var entity = await FindSupplierByIdAsync(idSupplier);
                entity!.State = 0;
            }




        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        }
}


