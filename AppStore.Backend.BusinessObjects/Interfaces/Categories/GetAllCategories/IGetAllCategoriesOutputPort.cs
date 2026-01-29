namespace AppStore.Backend.BusinessObjects.Interfaces.Categories.GetAllCategories
{
    public interface IGetAllCategoriesOutputPort
    {
        IEnumerable<CategoryItemDto> Categories { get; }
        Task Handle(IEnumerable<CategoryItemDto> categories);
    }
}
