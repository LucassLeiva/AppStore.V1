namespace AppStore.Backend.UseCases.Suppliers.UpdateSupplier
{
    internal class UpdateSupplierInteractor(
        IUpdateSupplierOutputPort outputPort,
        ICommandsRepository repository) : IUpdateSupplierInputPort
    {
        public async Task Handle(UpdateSupplierDto dto)
        {
            var supplier = new Supplier(
                dto.Name,
                dto.CUIT,
                dto.Address,
                dto.PhoneNumber,
                dto.Email,
                dto.City,
                dto.Country,
                dto.Postcode
            )
            {
                IdSupplier = dto.IdSupplier
            };

            int id = await repository.UpdateSupplier(supplier);
            await outputPort.Handle(id);
        }
    }
}
