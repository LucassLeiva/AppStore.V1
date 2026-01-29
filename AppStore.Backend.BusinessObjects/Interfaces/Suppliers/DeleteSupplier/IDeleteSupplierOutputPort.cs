using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.DeleteSupplier
{
    public interface IDeleteSupplierOutputPort
    {
        int IdSupplier { get; }
        Task Handle(int idSupplier);
    }
}
