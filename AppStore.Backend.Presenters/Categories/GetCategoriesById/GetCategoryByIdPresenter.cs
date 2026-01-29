namespace AppStore.Backend.Presenters.Categories.GetCategoriesById
{
    internal class GetCategoryByIdPresenter : IGetCategoryByIdOutputPort
    {
        public CategoryItemDto? Category { get; private set; }

        public Task Handle(CategoryItemDto? category)
        {
            Category = category;
            return Task.CompletedTask;
        }
    }
}
