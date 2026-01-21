using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Backend.BusinessObjects.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.Presenters.CreateSupplier
{
    internal class CreateSupplierPresenter : ICreateSupplierOutputPort
    {
        public int IdSupplier { get; private set; }

        public Task Handle(Supplier addedSupplier)
        {
            IdSupplier = addedSupplier.IdSupplier;
            return Task.CompletedTask;
        }
    }
}
