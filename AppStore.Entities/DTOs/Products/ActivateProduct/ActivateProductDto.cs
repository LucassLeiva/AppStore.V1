using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Products.ActivateProduct
{
    public class ActivateProductDto(int idProduct)
    {
        public int IdProduct => idProduct;
    }
}
