using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Products.UpdateProduct
{
    public class UpdateProductDto(
        int idProduct,
        int idCategory,
        string internalCode,
        string name,
        decimal price,
        string? description,
        int idSupplier
    )
    {
        public int IdProduct => idProduct;
        public int IdCategory => idCategory;
        public string InternalCode => internalCode;
        public string Name => name;
        public decimal Price => price;
        public string? Description => description;
        public int IdSupplier => idSupplier;
    }
}
