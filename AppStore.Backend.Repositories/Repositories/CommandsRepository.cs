using AppStore.Backend.BusinessObjects.Interfaces.Repositories;
using AppStore.Backend.BusinessObjects.POCOEntities;
using AppStore.Backend.Repositories.Entities;
using AppStore.Backend.Repositories.Interfaces;


namespace AppStore.Backend.Repositories.Repositories
{

    // ESTA CLASE ES UN TRADUCTOR O ADAPTADOR: ENTRE EL NEGOCIO(LO QUE SE QUIERE HACER EJ: CREAR PRODUCTO, GUARDAR STOCK) Y LA PERSISTENCIA(LO QUE SE ALMACENA EN LA BASE DE DATOS, Solo sabe guardar y leer datos)
    // RESUMINO, LA FUNCION DE ESTA CLASE ES “Agarro cosas del negocio y las transformo en algo que la base de datos entiende”.
    internal class CommandsRepository(IAppStoreCommandsDataContext context) : ICommandsRepository
    {
        public async Task<int> CreateStock(Stock stock)
        {
            var stockEntity = new StockEntity
            {
                Amount = stock.Amount,
                State = stock.State
            };

            await context.AddStockAsync(stockEntity);
            await context.SaveChangesAsync();     // acá EF asigna stockEntity.IdStock

            return stockEntity.IdStock;
        }


        public async Task UpdateStockAmount(int idStock, int amount)
        {
            var stock = await context.FindStockByIdAsync(idStock);
            if (stock == null) throw new InvalidOperationException("Stock no encontrado.");

            stock.Amount = amount;

            await context.SaveChangesAsync();
        }

        public async Task UpdateProductState(int idProduct, int state)
        {
            var product = await context.FindProductByIdAsync(idProduct);
            if (product == null) throw new InvalidOperationException("Producto no encontrado.");

            product.State = state;

            await context.SaveChangesAsync();
        }

        public async Task<int> CreateProduct(Product product)
        {
            var productEntity = new ProductEntity
            {
                IdCategory = product.IdCategory,
                InternalCode = product.InternalCode,
                Name = product.Name,
                Price = product.Price,
                IdStock = product.IdStock,
                Description = product.Description,
                State = product.State,
                IdSupplier = product.IdSupplier
            };

            await context.AddProductAsync(productEntity);
            await context.SaveChangesAsync();     // acá EF asigna productEntity.IdProducto

            return productEntity.IdProduct;
        }


        public async Task<int> UpdateProduct(Product product)
        {
            var productEntity = new ProductEntity
            {
                IdProduct = product.IdProduct,
                IdCategory = product.IdCategory,
                InternalCode = product.InternalCode,
                Name = product.Name,
                Price = product.Price,
                IdStock = product.IdStock,
                Description = product.Description,
                State = product.State,
                IdSupplier = product.IdSupplier
            };

            await context.UpdateProductAsync(productEntity);
            await context.SaveChangesAsync();

            return productEntity.IdProduct;
        }


        public async Task<int> DeleteProduct(int idProduct)
        {
            await context.SoftDeleteProductAsync(idProduct);
            await context.SaveChangesAsync();
            return idProduct;
        }




        public async Task<int> CreateCategory(Category category)
        {
            var entity = new CategoryEntity
            {
                Name = category.Name,
                Description = category.Description,
                State = category.State
            };

            await context.AddCategoryAsync(entity);
            await context.SaveChangesAsync();

            return entity.IdCategory;
        }

        public async Task<int> CreateSupplier(Supplier supplier)
        {
            var entity = new SupplierEntity
            {
                Name = supplier.Name,
                CUIT = supplier.CUIT,
                Address = supplier.Address,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email,
                City = supplier.City,
                Country = supplier.Country,
                Postcode = supplier.Postcode,
                State = supplier.State
            };

            await context.AddSupplierAsync(entity);
            await context.SaveChangesAsync();

            return entity.IdSupplier;
        }





        // Si tu IUnitOfWork todavía exige SaveChanges(), podés dejarlo igual:
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

      
    }
}
