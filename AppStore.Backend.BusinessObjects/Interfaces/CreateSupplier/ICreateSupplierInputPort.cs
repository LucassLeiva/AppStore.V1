using AppStore.Entities.DTOs.CreateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier
{
    public interface ICreateSupplierInputPort
    {
        Task Handle(CreateSupplierDto dto);
    }
}
