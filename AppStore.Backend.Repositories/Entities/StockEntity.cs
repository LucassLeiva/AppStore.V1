using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Repositories.Entities
{
    public class StockEntity
    {
        public int IdStock { get; set; }
        public int Amount { get; set; }
        public int State { get; set; } = 1;

        public ProductEntity? Product { get; set; } // 1–1 (opcional)
    }
}
