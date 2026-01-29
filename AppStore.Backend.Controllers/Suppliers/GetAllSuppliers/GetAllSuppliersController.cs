namespace Microsoft.AspNetCore.Builder
{
    public static class GetAllSuppliersController
    {
        public static WebApplication UseGetAllSuppliersController(this WebApplication app)
        {
            app.MapGet(Endpoints.GetAllSuppliers, GetAllSuppliers);
            return app;
        }

        public static async Task<IEnumerable<object>> GetAllSuppliers(
            bool includeInactive,
            IGetAllSuppliersInputPort inputPort,
            IGetAllSuppliersOutputPort presenter)
        {
            await inputPort.Handle(includeInactive);
            return presenter.Suppliers;
        }
    }
}
