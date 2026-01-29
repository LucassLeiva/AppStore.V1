namespace Microsoft.AspNetCore.Builder
{
    public static class DeleteCategoryController
    {
        public static WebApplication UseDeleteCategoryController(this WebApplication app)
        {
            app.MapDelete(Endpoints.DeleteCategory, DeleteCategory);
            return app;
        }

        public static async Task<int> DeleteCategory(
            int idCategory,
            IDeleteCategoryInputPort inputPort,
            IDeleteCategoryOutputPort presenter)
        {
            await inputPort.Handle(new DeleteCategoryDto(idCategory));
            return presenter.IdCategory;
        }
    }
}