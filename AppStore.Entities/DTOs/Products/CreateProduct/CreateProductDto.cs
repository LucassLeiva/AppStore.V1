using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Products.CreateProduct
{
    public class CreateProductDto(int idCategory, string internalCode, string name, decimal price, short stockInicial, string? description, int idSupplier, int state)
    {
        public int IdCategory => idCategory;
        public string InternalCode => internalCode;
        public string Name => name;
        public decimal Price => price;
        public short StockInicial => stockInicial;
        public string? Description => description;
        public int IdSupplier => idSupplier;
        public int State => state;

    }
}

