namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.GetAllSuppliers
{
    public interface IGetAllSuppliersInputPort
    {
        Task Handle(bool includeInactive);
    }
}
