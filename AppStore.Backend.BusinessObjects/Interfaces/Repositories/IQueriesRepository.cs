namespace AppStore.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface IQueriesRepository
    {
        Task<IEnumerable<AvailableCategory>> GetAvailableCategories();
        Task<IEnumerable<AvailableSupplier>> GetAvailableSuppliers();
        Task<IEnumerable<AvailableProduct>> GetAvailableProducts();

    }
}
