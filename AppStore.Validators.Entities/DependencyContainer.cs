namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddValidators(
    this IServiceCollection services)
    {
        services.AddModelValidator<CreateProductDto,
        CreateProductDtoValidator>();

        return services;
    }
}
