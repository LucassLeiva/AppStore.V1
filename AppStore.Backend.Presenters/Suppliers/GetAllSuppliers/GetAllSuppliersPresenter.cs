namespace AppStore.Backend.Presenters.Suppliers.GetAllSuppliers
{
    internal class GetAllSuppliersPresenter : IGetAllSuppliersOutputPort
    {
        public IEnumerable<SupplierItemDto> Suppliers { get; private set; } = [];

        public Task Handle(IEnumerable<SupplierItemDto> suppliers)
        {
            Suppliers = suppliers;
            return Task.CompletedTask;
        }
    }
}
