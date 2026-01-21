using AppStore.Entities.DTOs.Products.CreateProduct;

namespace Microsoft.AspNetCore.Builder;

public static class CreateProductController
{
    public static WebApplication UseCreateProductController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateProduct, CreateProduct);
        return app;
    }

    public static async Task<int> CreateProduct(
        CreateProductDto productDto,
        ICreateProductInputPort inputPort,
        ICreateProductOutputPort presenter)
    {
        await inputPort.Handle(productDto);
        return presenter.IdProduct;
    }
}
