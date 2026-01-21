using AppStore.Backend.BusinessObjects.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier
{
    public interface ICreateSupplierOutputPort
    {
        int IdSupplier { get; }
        Task Handle(Supplier addedSupplier);
    }
}
