namespace Microsoft.AspNetCore.Builder
{
    public static class ActivateProductController
    {
        public static WebApplication UseActivateProductController(this WebApplication app)
        {
            app.MapPut(Endpoints.ActivateProduct, ActivateProduct);
            return app;
        }

        public static async Task<int> ActivateProduct(
            int idProduct,
            IActivateProductInputPort inputPort,
            IActivateProductOutputPort presenter)
        {
            await inputPort.Handle(new ActivateProductDto(idProduct));
            // devuelve el id como tu Delete
            return presenter.IdProduct;
        }
    }
}
