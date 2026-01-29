using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsRepository : IUnitOfWork
    {
        //Products Commands
        Task<int> CreateProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int idProduct);

        //Stocks Commands
        Task UpdateStockAmount(int idStock, int amount);
        Task UpdateProductState(int idProduct, int state);
        Task<int> CreateStock(Stock stock);

        //Category Commands
        Task<int> CreateCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int idCategory);

        //Supplier Commands
        Task<int> CreateSupplier(Supplier supplier);
        Task<int> UpdateSupplier(Supplier supplier);
        Task<int> DeleteSupplier(int idSupplier);
    }
}
