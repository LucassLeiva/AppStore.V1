namespace AppStore.Backend.Presenters.Suppliers.GetSupplierById
{
    internal class GetSupplierByIdPresenter : IGetSupplierByIdOutputPort
    {
        public SupplierItemDto? Supplier { get; private set; }

        public Task Handle(SupplierItemDto? supplier)
        {
            Supplier = supplier;
            return Task.CompletedTask;
        }
    }
}
