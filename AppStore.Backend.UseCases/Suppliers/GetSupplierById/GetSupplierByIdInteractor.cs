namespace AppStore.Backend.UseCases.Suppliers.GetSupplierById
{
    internal class GetSupplierByIdInteractor(
        IQueriesRepository repository,
        IGetSupplierByIdOutputPort outputPort) : IGetSupplierByIdInputPort
    {
        public async Task Handle(int idSupplier)
        {
            var supplier = await repository.GetSupplierById(idSupplier);
            await outputPort.Handle(supplier);
        }
    }
}
