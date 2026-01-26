using AppStore.Backend.BusinessObjects.Interfaces.Products.GetById;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class GetProductByIdController
    {
        public static WebApplication UseGetProductByIdController(this WebApplication app)
        {
            app.MapGet(Endpoints.GetProductById, GetProductById);
            return app;
        }

        public static async Task<object?> GetProductById(
            int idProduct,
            IGetProductByIdInputPort inputPort,
            IGetProductByIdOutputPort presenter)
        {
            await inputPort.Handle(idProduct);
            return presenter.Product is null ? Results.NotFound() : Results.Ok(presenter.Product);
        }
    }
}
