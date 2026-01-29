namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.UpdateSupplier
{
    public interface IUpdateSupplierInputPort
    {
        Task Handle(UpdateSupplierDto dto);
    }
}
