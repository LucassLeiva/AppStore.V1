namespace Microsoft.AspNetCore.Builder
{
    public static class UpdateProductController
    {
        public static WebApplication UseUpdateProductController(this WebApplication app)
        {
            app.MapPut(Endpoints.UpdateProduct, UpdateProduct);
            return app;
        }

        public static async Task<int> UpdateProduct(
            UpdateProductDto dto,
            IUpdateProductInputPort inputPort,
            IUpdateProductOutputPort presenter)
        {
            await inputPort.Handle(dto);
            return presenter.IdProduct;
        }
    }
}
