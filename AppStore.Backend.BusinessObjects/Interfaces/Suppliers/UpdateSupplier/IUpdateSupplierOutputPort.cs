namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.UpdateSupplier
{
    public interface IUpdateSupplierOutputPort
    {
        int IdSupplier { get; }
        Task Handle(int idSupplier);
    }
}
