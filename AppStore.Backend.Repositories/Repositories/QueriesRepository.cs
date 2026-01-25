using AppStore.Backend.BusinessObjects.ValueObjects;
using AppStore.Backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Repositories.Repositories
{
    internal class QueriesRepository(IAppStoreQueriesDataContext context) : IQueriesRepository
    {
        public async Task<IEnumerable<AvailableCategory>> GetAvailableCategories()
        {
            var Queryable = context.Category
                // si tenés soft delete / active flag, lo filtrás acá:
                // .Where(c => c.IsActive)
                .Select(c => new AvailableCategory(
                    c.IdCategory,
                    c.Name
                ));

            return await context.ToListAsync(Queryable);
        }

        public async Task<IEnumerable<AvailableSupplier>> GetAvailableSuppliers()
        {
            var Queryable = context.Supplier
                // si aplica:
                // .Where(s => s.IsActive)
                .Select(s => new AvailableSupplier(
                    s.IdSupplier,
                    s.Name
                ));

            return await context.ToListAsync(Queryable);
        }
        public async Task<IEnumerable<AvailableProduct>> GetAvailableProducts()
        {
            var queryable = context.Product
                .Select(p => new AvailableProduct(p.IdProduct, p.InternalCode));

            return await context.ToListAsync(queryable);
        }
    }
}
