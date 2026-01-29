namespace AppStore.Backend.BusinessObjects.Interfaces.Suppliers.GetAllSuppliers
{
    public interface IGetAllSuppliersOutputPort
    {
        IEnumerable<SupplierItemDto> Suppliers { get; }
        Task Handle(IEnumerable<SupplierItemDto> suppliers);
    }
}
