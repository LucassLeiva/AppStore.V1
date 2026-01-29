namespace AppStore.Backend.UseCases.Suppliers.GetAllSuppliers
{
    internal class GetAllSuppliersInteractor(
       IQueriesRepository repository,
       IGetAllSuppliersOutputPort outputPort) : IGetAllSuppliersInputPort
    {
        public async Task Handle(bool includeInactive)
        {
            var suppliers = await repository.GetAllSuppliers(includeInactive);
            await outputPort.Handle(suppliers);
        }
    }
}
