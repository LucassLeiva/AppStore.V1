namespace AppStore.Backend.Repositories.Interfaces
{
    public interface IAppStoreQueriesDataContext
    {
        IQueryable<ProductEntity> Product { get; }
        IQueryable<CategoryEntity> Category { get; }
        IQueryable<SupplierEntity> Supplier { get; }
        IQueryable<StockEntity> Stock { get; }
        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> queryable);
        Task<IEnumerable<T>> ToListAsync<T>(IQueryable<T> queryable);
    }
}
