namespace AppStore.Backend.UseCases.Categories.GetCategoriesById
{
    internal class GetCategoryByIdInteractor(
       IQueriesRepository repository,
       IGetCategoryByIdOutputPort outputPort) : IGetCategoryByIdInputPort
    {
        public async Task Handle(int idCategory)
        {
            var category = await repository.GetCategoryById(idCategory);
            await outputPort.Handle(category);
        }
    }
}
