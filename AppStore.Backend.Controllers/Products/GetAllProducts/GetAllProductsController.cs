namespace Microsoft.AspNetCore.Builder
{
    public static class GetAllProductsController
    {
        public static WebApplication UseGetAllProductsController(this WebApplication app)
        {
            app.MapGet(Endpoints.GetAllProducts, GetAllProducts);
            return app;
        }

        public static async Task<IEnumerable<object>> GetAllProducts(
            bool includeInactive,
            IGetAllProductsInputPort inputPort,
            IGetAllProductsOutputPort presenter)
        {
            await inputPort.Handle(includeInactive);
            return presenter.Products;
        }
    }
}