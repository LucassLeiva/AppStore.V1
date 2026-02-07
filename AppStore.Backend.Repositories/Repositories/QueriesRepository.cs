//Preguntar si esta bien implementar EntityFrameworkCore en esta capa
//using Microsoft.EntityFrameworkCore;

namespace AppStore.Backend.Repositories.Repositories
{
    internal class QueriesRepository(IAppStoreQueriesDataContext context) : IQueriesRepository

    {

        //Queries para Validaciones
        public async Task<IEnumerable<AvailableCategory>> GetAvailableCategories()
        {
            var queryable = context.Category
                .Where(c => c.State == 1)
                .Select(c => new AvailableCategory(
                    c.IdCategory,
                    c.Name
                ));

            return await context.ToListAsync(queryable);
        }


        public async Task<IEnumerable<AvailableSupplier>> GetAvailableSuppliers()
        {
            var queryable = context.Supplier
                .Where(c => c.State == 1  )
                .Select(s => new AvailableSupplier(
                    s.IdSupplier,
                    s.Name
                ));

            return await context.ToListAsync(queryable);
        }
        public async Task<IEnumerable<AvailableProduct>> GetAvailableProducts()
        {
            var queryable = context.Product
                
                .Select(p => new AvailableProduct(p.IdProduct, p.InternalCode));

            return await context.ToListAsync(queryable);
        }


        //Queries para PRODUCTS
        public async Task<IEnumerable<ProductItemDto>> GetAllProducts(bool includeInactive)
        {
            var queryable = 
                from p in context.Product
                join c in context.Category on p.IdCategory equals c.IdCategory
                join s in context.Supplier on p.IdSupplier equals s.IdSupplier
                join st in context.Stock on p.IdStock equals st.IdStock
                where includeInactive || p.State == 1
                select new ProductItemDto(
                    p.IdProduct,
                    p.InternalCode,
                    p.Name,
                    p.Price,
                    st.Amount,
                    p.State,
                    c.IdCategory,
                    c.Name,
                    s.IdSupplier,
                    s.Name
                    

                );

            return await context.ToListAsync(queryable);
        }

        public async Task<ProductDetailsDto?> GetProductById(int idProduct)
        {
            var queryable =
                from p in context.Product
                join c in context.Category on p.IdCategory equals c.IdCategory
                join s in context.Supplier on p.IdSupplier equals s.IdSupplier
                join st in context.Stock on p.IdStock equals st.IdStock
                where p.IdProduct == idProduct
                select new ProductDetailsDto(
                    p.IdProduct,
                    p.InternalCode,
                    p.Name,
                    p.Price,
                    st.Amount,
                    p.State,
                    c.IdCategory,
                    c.Name,
                    s.IdSupplier,
                    s.Name,
                    p.Description
                   
                    
                    
                );

            return await context.FirstOrDefaultAsync(queryable);
        }

        public async Task<bool> ProductExists(int idProduct)
        {
            var queryable = context.Product
                .Where(p => p.IdProduct == idProduct)
                .Select(p => p.IdProduct);

            var result = await context.FirstOrDefaultAsync(queryable);
            return result != default;
        }

        public async Task<int> GetStockIdByProductId(int idProduct)
        {
            var queryable = context.Product
                .Where(p => p.IdProduct == idProduct)
                .Select(p => p.IdStock);

            // Si el producto no existe, FirstOrDefaultAsync devuelve 0 (default int)
            return await context.FirstOrDefaultAsync(queryable);
        }




        //Queries para Categories

        public async Task<IEnumerable<CategoryItemDto>> GetAllCategories(bool includeInactive)
        {
            var queryable = context.Category
                .Where(c => includeInactive || c.State == 1)
                .Select(c => new CategoryItemDto(
                    c.IdCategory,
                    c.Name,
                    c.Description,
                    c.State
                ));

            return await context.ToListAsync(queryable);
        }

        public async Task<CategoryItemDto?> GetCategoryById(int idCategory)
        {
            var queryable = context.Category
                .Where(c => c.IdCategory == idCategory)
                .Select(c => new CategoryItemDto(
                    c.IdCategory,
                    c.Name,
                    c.Description,
                    c.State));

            return await context.FirstOrDefaultAsync(queryable);
        }

        //Queries para Suppliers
        public async Task<IEnumerable<SupplierItemDto>> GetAllSuppliers(bool includeInactive)
        {
            var queryable = context.Supplier
                .Where(s => includeInactive || s.State == 1)
                .Select(s => new SupplierItemDto(
                    s.IdSupplier,
                    s.Name,
                    s.CUIT,
                    s.Address,
                    s.PhoneNumber,
                    s.Email,
                    s.City,
                    s.Country,
                    s.Postcode,
                    s.State
                ));

            return await context.ToListAsync(queryable);
        }

        public async Task<SupplierItemDto?> GetSupplierById(int idSupplier)
        {
            var queryable = context.Supplier
                .Where(s => s.IdSupplier == idSupplier)
                .Select(s => new SupplierItemDto(
                    s.IdSupplier,
                    s.Name,
                    s.CUIT,
                    s.Address,
                    s.PhoneNumber,
                    s.Email,
                    s.City,
                    s.Country,
                    s.Postcode,
                    s.State
                ));

            return await context.FirstOrDefaultAsync(queryable);
        }

    }
}
