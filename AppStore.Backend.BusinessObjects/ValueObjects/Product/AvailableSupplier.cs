using AppStore.Backend.BusinessObjects.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.ValueObjects.Product
{
    public class AvailableSupplier(int idSupplier, string name)
    {
        public int IdSupplier => idSupplier;
        public string Name => name;
    }
}
