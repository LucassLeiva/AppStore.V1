namespace Microsoft.AspNetCore.Builder
{
    public static class DeleteProductController
    {
        public static WebApplication UseDeleteProductController(this WebApplication app)
        {
            app.MapDelete(Endpoints.DeleteProduct, DeleteProduct);
            return app;
        }

        public static async Task<int> DeleteProduct(int idProduct,IDeleteProductInputPort inputPort, IDeleteProductOutputPort presenter)
        {
            await inputPort.Handle(new DeleteProductDto(idProduct));
            return presenter.IdProduct;
        }
    }
}
