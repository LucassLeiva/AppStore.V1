using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsRepository : IUnitOfWork
    {

        //Products Commands
        Task<(int IdProduct, int IdStock)> CreateProductWithInitialStock(Product product, Stock stock);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int idProduct);
        

        //Stocks Commands
        Task UpdateStockAmount(int idStock, int amount);
        Task UpdateProductState(int idProduct, int state);
        

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
