using AppStore.Backend.BusinessObjects.POCOEntities;

namespace AppStore.Backend.Repositories.Repositories
{

    // ESTA CLASE ES UN TRADUCTOR O ADAPTADOR: ENTRE EL NEGOCIO(LO QUE SE QUIERE HACER EJ: CREAR PRODUCTO, GUARDAR STOCK) Y LA PERSISTENCIA(LO QUE SE ALMACENA EN LA BASE DE DATOS, Solo sabe guardar y leer datos)
    // RESUMINO, LA FUNCION DE ESTA CLASE ES “Agarro cosas del negocio y las transformo en algo que la base de datos entiende”.
    internal class CommandsRepository(IAppStoreCommandsDataContext context) : ICommandsRepository
    {
        private Product? _pendingProduct;
        private Stock? _pendingStock;
        private ProductEntity? _pendingProductEntity;
        private StockEntity? _pendingStockEntity;
        
        //----------------------------------------------------------------Product Commands
        //public async Task<int> CreateProduct(Product product)
        //{
        //    var productEntity = new ProductEntity
        //    {
        //        IdCategory = product.IdCategory,
        //        InternalCode = product.InternalCode,
        //        Name = product.Name,
        //        Price = product.Price,
        //        IdStock = product.IdStock,
        //        Description = product.Description,
        //        State = product.State,
        //        IdSupplier = product.IdSupplier
        //    };

        //    await context.AddProductAsync(productEntity);
        //    await context.SaveChangesAsync();

        //    return productEntity.IdProduct;
        //}
        public async Task CreateProductWithInitialStock(Product product, Stock stock)
    {
        //Creamos las entidades EF
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

            //Seteamos la navegación
            Stock = stockEntity
        };

            //Agregamos SOLO el producto (si la relación está bien EF, inserta el Stock tambien )
            await context.AddProductAsync(productEntity);


            //En vez de SaveChanges, guardamos referencias para devolver IDs luego del SaveChanges()
            _pendingProduct = product;
            _pendingStock = stock;
            _pendingProductEntity = productEntity;
            _pendingStockEntity = stockEntity;
           
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

            await context.SaveChangesAsync();
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
        //public async Task<int> CreateStock(Stock stock)
        //{
        //    var stockEntity = new StockEntity
        //    {
        //        Amount = stock.Amount,
        //        State = stock.State
        //    };

        //    await context.AddStockAsync(stockEntity);
        //    await context.SaveChangesAsync();

        //    return stockEntity.IdStock;
        //}


        public async Task UpdateStockAmount(int idStock, int amount)
        {
            var stock = await context.FindStockByIdAsync(idStock);
            if (stock == null) throw new InvalidOperationException("Stock no encontrado.");

            stock.Amount = amount;

            await context.SaveChangesAsync();
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


        //public async Task<int> UpdateCategory(Category category)
        //{
        //    var entity = new CategoryEntity
        //    {
        //        IdCategory = category.IdCategory,
        //        Name = category.Name,
        //        Description = category.Description,
        //        State = category.State
        //    };

        //    await context.UpdateCategoryAsync(entity);
        //    await context.SaveChangesAsync();

        //    return entity.IdCategory;
        //}

        public async Task<int> UpdateCategory(Category category)
        {
            var entity = await context.FindCategoryByIdAsync(category.IdCategory);
            if (entity == null)
                throw new InvalidOperationException("Categoría no encontrada.");

            entity.Name = category.Name;
            entity.Description = category.Description;
            // Si tu regla es que el update NO cambia el State, no lo toques.
            // Si sí lo cambia:
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

        //public async Task<int> UpdateSupplier(Supplier supplier)
        //{
        //    var entity = new SupplierEntity
        //    {
        //        IdSupplier = supplier.IdSupplier,
        //        Name = supplier.Name,
        //        CUIT = supplier.CUIT,
        //        Address = supplier.Address,
        //        PhoneNumber = supplier.PhoneNumber,
        //        Email = supplier.Email,
        //        City = supplier.City,
        //        Country = supplier.Country,
        //        Postcode = supplier.Postcode,
        //        State = supplier.State
        //    };

        //    await context.UpdateSupplierAsync(entity);
        //    await context.SaveChangesAsync();

        //    return entity.IdSupplier;
        //}

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




        // Si tu IUnitOfWork todavía exige SaveChanges(), podés dejarlo igual:
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();

            // ✅ Después del commit EF ya llenó los IDs
            if (_pendingProduct != null && _pendingStock != null &&
            _pendingProductEntity != null && _pendingStockEntity != null)
            {
                _pendingStock.IdStock = _pendingStockEntity.IdStock;
                _pendingProduct.IdProduct = _pendingProductEntity.IdProduct;

                // ✅ acá se cumple la regla de dominio “producto debe tener stock”
                _pendingProduct.AttachStock(_pendingStock.IdStock);

                // opcional: limpiar
                _pendingProduct = null;
                _pendingStock = null;
                _pendingProductEntity = null;
                _pendingStockEntity = null;
            }
        }

      
    }
}
