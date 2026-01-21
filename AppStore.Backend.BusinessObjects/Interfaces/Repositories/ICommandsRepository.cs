using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsRepository : IUnitOfWork
    {
        Task<int> CreateProduct(Product product);
        Task<int> CreateStock(Stock stock);
        Task<int> CreateCategory(Category category);
        Task<int> CreateSupplier(Supplier supplier);
    }
}
