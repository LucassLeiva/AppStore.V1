using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.Repositories.Repositories
{

    // ESTA CLASE ES UN TRADUCTOR O ADAPTADOR: ENTRE EL NEGOCIO(LO QUE SE QUIERE HACER EJ: CREAR PRODUCTO, GUARDAR STOCK) Y LA PERSISTENCIA(LO QUE SE ALMACENA EN LA BASE DE DATOS, Solo sabe guardar y leer datos)
    // RESUMINO, LA FUNCION DE ESTA CLASE ES “Agarro cosas del negocio y las transformo en algo que la base de datos entiende”.
    internal class CommandsRepository(IAppStoreCommandsDataContext context) : ICommandsRepository
    {
       

        //----------------------------------------------------------------Product Commands
        public async Task<(int IdProduct, int IdStock)> CreateProductWithInitialStock(Product product, Stock stock)
        {
            var stockEntity = new StockEntity
            {
                Amount = stock.Amount,
                State = stock.State
            };

            var productEntity = new ProductEntity
            {
                IdCategory = product.IdCategory,
                InternalCode = product.InternalCode,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                State = product.State,
                IdSupplier = product.IdSupplier,
                Stock = stockEntity
            };

            await context.AddProductAsync(productEntity);
            await context.SaveChangesAsync();
            return (productEntity.IdProduct, stockEntity.IdStock);
        }


        public async Task<int> UpdateProduct(Product product)
        {
            var productEntity = await context.FindProductByIdAsync(product.IdProduct);
            if (productEntity == null)
                throw new InvalidOperationException("Producto no encontrado.");

            productEntity.IdCategory = product.IdCategory;
            productEntity.InternalCode = product.InternalCode;
            productEntity.Name = product.Name;
            productEntity.Price = product.Price;
            productEntity.Description = product.Description;
            productEntity.IdSupplier = product.IdSupplier;

          
            return productEntity.IdProduct;
        }

        public async Task UpdateProductState(int idProduct, int state)
        {
            var product = await context.FindProductByIdAsync(idProduct);
            if (product == null) 
            throw new InvalidOperationException("Producto no encontrado.");

            product.State = state;

            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int idProduct)
        {
            await context.SoftDeleteProductAsync(idProduct);
            await context.SaveChangesAsync();
            return idProduct;
        }

        //-------------------------------------------------------------------------Stock Commands


        public async Task UpdateStockAmount(int idStock, int amount)
        {
            var stock = await context.FindStockByIdAsync(idStock);
            if (stock == null) throw new InvalidOperationException("Stock no encontrado.");

            stock.Amount = amount;

            
        }

        //---------------------------------------------------------------------Category Commands

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



        public async Task<int> UpdateCategory(Category category)
        {
            var entity = await context.FindCategoryByIdAsync(category.IdCategory);
            if (entity == null)
                throw new InvalidOperationException("Categoría no encontrada.");

            entity.Name = category.Name;
            entity.Description = category.Description;
            entity.State = category.State;

            await context.SaveChangesAsync();
            return entity.IdCategory;
        }

        public async Task<int> DeleteCategory(int idCategory)
        {
            await context.SoftDeleteCategoryAsync(idCategory);
            await context.SaveChangesAsync();
            return idCategory;
        }




        //------------------------------------------------------------------Supplier Commands

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


        public async Task<int> UpdateSupplier(Supplier supplier)
        {
            var entity = await context.FindSupplierByIdAsync(supplier.IdSupplier);
                
            if (entity == null)
                throw new InvalidOperationException("Proveedor no encontrado.");

            entity.Name = supplier.Name;
            entity.CUIT = supplier.CUIT;
            entity.Address = supplier.Address;
            entity.PhoneNumber = supplier.PhoneNumber;
            entity.Email = supplier.Email;
            entity.City = supplier.City;
            entity.Country = supplier.Country;
            entity.Postcode = supplier.Postcode;
            entity.State = supplier.State;

            await context.SaveChangesAsync();
            return entity.IdSupplier;
        }

        public async Task<int> DeleteSupplier(int idSupplier)
        {
            await context.SoftDeleteSupplierAsync(idSupplier);
            await context.SaveChangesAsync();
            return idSupplier;
        }
  
        public Task SaveChanges() => context.SaveChangesAsync();


    }
}
