using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.DataContexts.EFCore.Services
{
    internal class AppStoreQueriesDataContext :
        AppStoreProductionContext,
        IAppStoreQueriesDataContext
    {
        public AppStoreQueriesDataContext(IOptions<DBOptions> dbOptions)
            : base(dbOptions)
        {
            ChangeTracker.QueryTrackingBehavior =
                QueryTrackingBehavior.NoTracking;
        }

        // Exponemos los DbSet como IQueryable (solo lectura)
        public new IQueryable<ProductEntity> Product => base.Product;
        public new IQueryable<CategoryEntity> Category => base.Category;
        public new IQueryable<SupplierEntity> Supplier => base.Supplier;
        public new IQueryable<StockEntity> Stock => base.Stock;

        // Helpers genéricos (igual al manual)
        public Task<T?> FirstOrDefaultAsync<T>(
            IQueryable<T> queryable) =>
            queryable.FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> ToListAsync<T>(
            IQueryable<T> queryable) =>
            await queryable.ToListAsync();
    }
}
