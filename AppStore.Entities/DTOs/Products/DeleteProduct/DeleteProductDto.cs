using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Products.DeleteProduct
{
    public class DeleteProductDto(int idProduct)
    {
        public int IdProduct => idProduct;
        
    }
}
