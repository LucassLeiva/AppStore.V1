using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppStore.Backend.BusinessObjects.POCOEntities
{
    public class Stock
    {
        public int IdStock { get; set; }
        public int Amount { get; set; }
        public int State { get; set; } = 1;

        protected Stock() { }

        public Stock(int cantidad)
        {
            if (cantidad <= 0) throw new ArgumentException("El stock no puede ser negativo");
            Amount = cantidad;
        }

    }
}
