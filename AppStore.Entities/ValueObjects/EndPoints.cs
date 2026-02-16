using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.ValueObjects
{

    //El uso de endpoints previene los string magicos. Un string mágico es un texto escrito “a mano” que no tiene consistencia,
    //si se cambia en un lado hay que cambiarlo manualmente en todo el codigo pudiendo producir bugs.
    public class Endpoints
    {
        //Products
        public const string CreateProduct = $"/{nameof(CreateProduct)}";
        public const string GetAllProducts = $"/{nameof(GetAllProducts)}";
        public const string GetProductById = $"/{nameof(GetProductById)}";
        public const string UpdateProduct = $"/{nameof(UpdateProduct)}";
        public const string UpdateProductWithStock = $"/{nameof(UpdateProductWithStock)}";
        public const string DeleteProduct = $"/{nameof(DeleteProduct)}";
        public const string ActivateProduct = $"/{nameof(ActivateProduct)}";



        //Categories
        public const string CreateCategory = $"/{nameof(CreateCategory)}";
        public const string GetAllCategories = $"/{nameof(GetAllCategories)}";
        public const string GetCategoryById = $"/{nameof(GetCategoryById)}/{{idCategory:int}}";
        public const string UpdateCategory = $"/{nameof(UpdateCategory)}";
        public const string DeleteCategory = $"/{nameof(DeleteCategory)}/{{idCategory:int}}";



        //Suppliers
        public const string CreateSupplier = $"/{nameof(CreateSupplier)}";
        public const string GetAllSuppliers = $"/{nameof(GetAllSuppliers)}";
        public const string GetSupplierById = $"/{nameof(GetSupplierById)}/{{idSupplier:int}}";
        public const string UpdateSupplier = $"/{nameof(UpdateSupplier)}";
        public const string DeleteSupplier = $"/{nameof(DeleteSupplier)}/{{idSupplier:int}}";

        //Stocks
        public const string UpdateStock = $"/{nameof(UpdateStock)}";
    }
}
