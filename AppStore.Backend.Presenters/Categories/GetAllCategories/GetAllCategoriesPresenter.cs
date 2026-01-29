namespace AppStore.Backend.Presenters.Categories.GetAllCategories
{
    internal class GetAllCategoriesPresenter : IGetAllCategoriesOutputPort
    {
        public IEnumerable<CategoryItemDto> Categories { get; private set; } = [];

        public Task Handle(IEnumerable<CategoryItemDto> categories)
        {
            Categories = categories;
            return Task.CompletedTask;
        }
    }
}
