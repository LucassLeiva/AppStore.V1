namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddValidators(
    this IServiceCollection services)
    {
        services.AddModelValidator<CreateProductDto, CreateProductDtoValidator>();
        services.AddModelValidator<UpdateProductDto, UpdateProductDtoValidator>();
        services.AddModelValidator<UpdateStockDto,UpdateStockDtoValidator>();
        services.AddModelValidator<DeleteProductDto,DeleteProductDtoValidator>();
        services.AddModelValidator<ActivateProductDto, ActivateProductDtoValidator>();

        return services;
    }
}
