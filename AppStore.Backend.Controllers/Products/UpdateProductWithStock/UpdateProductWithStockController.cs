namespace Microsoft.AspNetCore.Builder
{
    public static class UpdateProductWithStockController
    {
        public static WebApplication UseUpdateProductWithStockController(this WebApplication app)
        {
            app.MapPut(Endpoints.UpdateProductWithStock, UpdateProductWithStock);
            return app;
        }

        public static async Task<int> UpdateProductWithStock(
            UpdateProductWithStockDto dto,
            IUpdateProductWithStockInputPort inputPort,
            IUpdateProductWithStockOutputPort presenter)
        {
            await inputPort.Handle(dto);
            return presenter.IdProduct;
                
        }
    }
}
