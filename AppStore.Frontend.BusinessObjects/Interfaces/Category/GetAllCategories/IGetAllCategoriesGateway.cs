namespace AppStore.Frontend.BusinessObjects.Interfaces.Category.GetAllCategories
{
    public interface IGetAllCategoriesGateway
    {
        Task<IEnumerable<CategoryItemDto>> GetAllAsync(bool includeInactive);
    }
}
