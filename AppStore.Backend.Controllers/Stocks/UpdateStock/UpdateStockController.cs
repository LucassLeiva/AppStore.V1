namespace Microsoft.AspNetCore.Builder
{
    public static class UpdateStockController
    {
        public static WebApplication UseUpdateStockController(this WebApplication app)
        {
            app.MapPut(Endpoints.UpdateStock, UpdateStock);
            return app;
        }

        public static async Task<int> UpdateStock(
            UpdateStockDto dto,
            IUpdateStockInputPort inputPort,
            IUpdateStockOutputPort presenter)
        {
            await inputPort.Handle(dto);
            return presenter.IdProduct;
        }
    }
}
