namespace AppStore.Backend.Presenters.Suppliers.DeleteSupplier
{
    internal class DeleteSupplierPresenter : IDeleteSupplierOutputPort
    {
        public int IdSupplier { get; private set; }

        public Task Handle(int idSupplier)
        {
            IdSupplier = idSupplier;
            return Task.CompletedTask;
        }
    }
}
