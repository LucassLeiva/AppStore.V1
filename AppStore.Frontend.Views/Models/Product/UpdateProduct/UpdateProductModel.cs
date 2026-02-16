using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.Views.Models.Product.UpdateProduct
{
    public class UpdateProductModel
    {
        public int IdProduct { get; set; }
        public string InternalCode { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public string? Description { get; set; } 
        public int IdCategory { get; set; }
        public int IdSupplier { get; set; }
        public int StockAmount { get; set; }
        public IEnumerable<CategoryItemDto> Categories { get; set; } = [];
        public IEnumerable<SupplierItemDto> Suppliers { get; set; } = [];

    }
}
