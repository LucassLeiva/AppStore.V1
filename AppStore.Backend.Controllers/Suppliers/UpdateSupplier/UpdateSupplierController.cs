namespace AppStore.Backend.Controllers.Suppliers.UpdateSupplier
{
    namespace Microsoft.AspNetCore.Builder
    {
        public static class UpdateSupplierController
        {
            public static WebApplication UseUpdateSupplierController(this WebApplication app)
            {
                app.MapPut(Endpoints.UpdateSupplier, UpdateSupplier);
                return app;
            }

            public static async Task<int> UpdateSupplier(
                UpdateSupplierDto dto,
                IUpdateSupplierInputPort inputPort,
                IUpdateSupplierOutputPort presenter)
            {
                await inputPort.Handle(dto);
                return presenter.IdSupplier;
            }
        }
    }
}
