using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Products.GetProducts
{
    public class ProductDetailsDto(
        int idProduct,
        string internalCode,
        string name,
        decimal price,
        int stockAmount,
        int state,
        int idCategory,
        string categoryName,
        int idSupplier,
        string supplierName,
        string? description
        
    )
    {
        
        public int IdProduct => idProduct;
        public string InternalCode => internalCode;
        public string Name => name;
        public decimal Price => price;
        public int StockAmount => stockAmount;
        public int State => state;

        public int IdCategory => idCategory;
        public string CategoryName => categoryName;

        public int IdSupplier => idSupplier;
        public string SupplierName => supplierName;

        public string? Description => description;
        
    }
}
