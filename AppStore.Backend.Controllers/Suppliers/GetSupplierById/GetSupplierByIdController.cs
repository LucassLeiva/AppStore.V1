namespace Microsoft.AspNetCore.Builder
{
    public static class GetSupplierByIdController
    {
        public static WebApplication UseGetSupplierByIdController(this WebApplication app)
        {
            app.MapGet(Endpoints.GetSupplierById, GetSupplierById);
            return app;
        }

        public static async Task<object?> GetSupplierById(
            int idSupplier,
            IGetSupplierByIdInputPort inputPort,
            IGetSupplierByIdOutputPort presenter)
        {
            await inputPort.Handle(idSupplier);
            return presenter.Supplier;
        }
    }
}