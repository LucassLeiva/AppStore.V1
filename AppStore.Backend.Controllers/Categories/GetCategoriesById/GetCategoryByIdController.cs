namespace AppStore.Backend.Controllers.Categories.GetCategoriesById
{
    namespace Microsoft.AspNetCore.Builder
    {
        public static class GetCategoryByIdController
        {
            public static WebApplication UseGetCategoryByIdController(this WebApplication app)
            {
                app.MapGet(Endpoints.GetCategoryById, GetCategoryById);
                return app;
            }

            public static async Task<object?> GetCategoryById(
                int idCategory,
                IGetCategoryByIdInputPort inputPort,
                IGetCategoryByIdOutputPort presenter)
            {
                await inputPort.Handle(idCategory);
                return presenter.Category;
            }
        }
    }
}
