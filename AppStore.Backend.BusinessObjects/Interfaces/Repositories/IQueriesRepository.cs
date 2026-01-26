using AppStore.Entities.DTOs.Products.GetProducts.AppStore.Entities.DTOs.Products;
using AppStore.Entities.DTOs.Products.GetProducts;

namespace AppStore.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface IQueriesRepository
    {
        //Para validar Categorias, Proveedores, Productos validos.
        Task<IEnumerable<AvailableCategory>> GetAvailableCategories();
        Task<IEnumerable<AvailableSupplier>> GetAvailableSuppliers();
        Task<IEnumerable<AvailableProduct>> GetAvailableProducts();


        //Queries para Products
        Task<IEnumerable<ProductItemDto>> GetAllProducts(bool includeInactive);
        Task<ProductDetailsDto?> GetProductById(int idProduct);

        //Queries para Stock
        Task<int> GetStockIdByProductId(int idProduct);
        Task<bool> ProductExists(int idProduct);
    }
}
