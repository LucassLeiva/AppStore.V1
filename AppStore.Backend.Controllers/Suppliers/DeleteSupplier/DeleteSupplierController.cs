namespace Microsoft.AspNetCore.Builder
{
    public static class DeleteSupplierController
    {
        public static WebApplication UseDeleteSupplierController(this WebApplication app)
        {
            app.MapDelete(Endpoints.DeleteSupplier, DeleteSupplier);
            return app;
        }

        public static async Task<int> DeleteSupplier(
            int idSupplier,
            IDeleteSupplierInputPort inputPort,
            IDeleteSupplierOutputPort presenter)
        {
            await inputPort.Handle(new DeleteSupplierDto(idSupplier));
            return presenter.IdSupplier;
        }
    }
}
