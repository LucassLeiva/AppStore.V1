using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Frontend.Views.Models.Product.CreateProduct
{
    public class CreateProductModel
    {
        public int IdCategory { get; set; }
        public string InternalCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short StockInicial { get; set; }
        public string? Description { get; set; }
        public int IdSupplier { get; set; }
        public int State { get; set; } = 1;

    }
}
