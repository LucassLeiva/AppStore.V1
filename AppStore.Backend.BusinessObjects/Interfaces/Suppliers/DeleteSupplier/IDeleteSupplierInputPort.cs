namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.DeleteSupplier
{
    public interface IDeleteSupplierInputPort
    {
        Task Handle(DeleteSupplierDto dto);
    }
}
