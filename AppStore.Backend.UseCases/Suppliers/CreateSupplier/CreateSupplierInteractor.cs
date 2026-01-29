using AppStore.Backend.BusinessObjects.Interfaces.Suppliers.CreateSupplier;
using AppStore.Entities.DTOs.Suppliers.CreateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.UseCases.Suppliers.CreateSupplier
{
    internal class CreateSupplierInteractor(
       ICreateSupplierOutputPort outputPort,
       ICommandsRepository repository) : ICreateSupplierInputPort
    {
        public async Task Handle(CreateSupplierDto dto)
        {
            var supplier = new Supplier(
                dto.Name,
                dto.CUIT,
                dto.Address,
                dto.PhoneNumber,
                dto.Email,
                dto.City,
                dto.Country,
                dto.Postcode,
                dto.State
            );

            int id = await repository.CreateSupplier(supplier);
            supplier.IdSupplier = id;

            await outputPort.Handle(supplier);
        }
    }
}
