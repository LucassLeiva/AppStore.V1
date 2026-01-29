namespace Microsoft.AspNetCore.Builder
{
    public static class UpdateCategoryController
    {
        public static WebApplication UseUpdateCategoryController(this WebApplication app)
        {
            app.MapPut(Endpoints.UpdateCategory, UpdateCategory);
            return app;
        }

        public static async Task<int> UpdateCategory(
            UpdateCategoryDto dto,
            IUpdateCategoryInputPort inputPort,
            IUpdateCategoryOutputPort presenter)
        {
            await inputPort.Handle(dto);
            return presenter.IdCategory;
        }
    }
}