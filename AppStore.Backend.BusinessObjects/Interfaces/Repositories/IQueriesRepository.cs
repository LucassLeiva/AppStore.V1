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

        //Queries para Categories
        Task<IEnumerable<CategoryItemDto>> GetAllCategories(bool includeInactive);
        Task<CategoryItemDto?> GetCategoryById(int idCategory);
        //Queries para Suppliers
        Task<IEnumerable<SupplierItemDto>> GetAllSuppliers(bool includeInactive);
        Task<SupplierItemDto?> GetSupplierById(int idSupplier);
    }
}
