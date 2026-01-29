using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Entities.DTOs.Suppliers.DeleteSupplier
{
    public class DeleteSupplierDto(int idSupplier)
    {
        public int IdSupplier => idSupplier;
    }
}
