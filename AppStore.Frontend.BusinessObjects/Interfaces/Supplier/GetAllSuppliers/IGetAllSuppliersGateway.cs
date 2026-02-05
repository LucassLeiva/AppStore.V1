namespace AppStore.Frontend.BusinessObjects.Interfaces.Supplier.GetAllSuppliers
{
    public interface IGetAllSuppliersGateway
    {
        Task<IEnumerable<SupplierItemDto>> GetAllAsync(bool includeInactive);
    }
}
