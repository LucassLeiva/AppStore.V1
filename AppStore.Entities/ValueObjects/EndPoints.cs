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
        public const string GetProductById = $"/{nameof(GetProductById)}/{{idProduct:int}}";
        public const string UpdateProduct = $"/{nameof(UpdateProduct)}";
        public const string DeleteProduct = $"/{nameof(DeleteProduct)}/{{idProduct:int}}";



        //Categories
        public const string CreateCategory = $"/{nameof(CreateCategory)}";



        //Suppliers
        public const string CreateSupplier = $"/{nameof(CreateSupplier)}";

        //Stocks
        public const string UpdateStock = $"/{nameof(UpdateStock)}";
    }
}
