namespace Microsoft.AspNetCore.Builder
{
    public static class GetAllCategoriesController
    {
        public static WebApplication UseGetAllCategoriesController(this WebApplication app)
        {
            app.MapGet(Endpoints.GetAllCategories, GetAllCategories);
            return app;
        }

        public static async Task<IEnumerable<object>> GetAllCategories(
            bool includeInactive,
            IGetAllCategoriesInputPort inputPort,
            IGetAllCategoriesOutputPort presenter)
        {
            await inputPort.Handle(includeInactive);
            return presenter.Categories;
        }
    }
}
