using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.GetSupplierById
{
    public interface IGetSupplierByIdInputPort
    {
        Task Handle(int idSupplier);
    }
}
