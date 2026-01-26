using AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct;
using AppStore.Entities.DTOs.Products.CreateProduct;
using Microsoft.AspNetCore.Builder;

namespace AppStore.Backend.Controllers.Products.CreateProduct;

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
