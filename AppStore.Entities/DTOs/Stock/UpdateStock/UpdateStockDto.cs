using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Stock.UpdateStock
{
    public class UpdateStockDto(int idProduct, int amount)
    {
        public int IdProduct => idProduct;
        public int Amount => amount;
    }
}
