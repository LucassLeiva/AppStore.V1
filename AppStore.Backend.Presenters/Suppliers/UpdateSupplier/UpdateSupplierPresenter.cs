namespace AppStore.Backend.Presenters.Suppliers.UpdateSupplier
{
    internal class UpdateSupplierPresenter : IUpdateSupplierOutputPort
    {
        public int IdSupplier { get; private set; }

        public Task Handle(int idSupplier)
        {
            IdSupplier = idSupplier;
            return Task.CompletedTask;
        }
    }
}
