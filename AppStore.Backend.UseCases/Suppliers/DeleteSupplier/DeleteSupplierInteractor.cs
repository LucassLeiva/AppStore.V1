namespace AppStore.Backend.UseCases.Suppliers.DeleteSupplier
{
    internal class DeleteSupplierInteractor(
        IDeleteSupplierOutputPort outputPort,
        ICommandsRepository repository) : IDeleteSupplierInputPort
    {
        public async Task Handle(DeleteSupplierDto dto)
        {
            int id = await repository.DeleteSupplier(dto.IdSupplier);
            await outputPort.Handle(id);
        }
    }
}
