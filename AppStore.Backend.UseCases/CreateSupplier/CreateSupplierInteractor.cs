using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Entities.DTOs.CreateSupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Backend.UseCases.CreateSupplier
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
