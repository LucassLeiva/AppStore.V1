namespace AppStore.Backend.UseCases.Categories.GetAllCategories
{
    internal class GetAllCategoriesInteractor(
    IQueriesRepository repository,
    IGetAllCategoriesOutputPort outputPort) : IGetAllCategoriesInputPort
    {
        public async Task Handle(bool includeInactive)
        {
            var categories = await repository.GetAllCategories(includeInactive);
            await outputPort.Handle(categories);
        }
    }
}
