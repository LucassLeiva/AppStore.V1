namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways(this IServiceCollection services, Action<HttpClient> configureHttpClient)
    {
        services.AddHttpClient<ICreateProductGateway,CreateProductGateway>(configureHttpClient);
        services.AddHttpClient<IGetAllProductsGateway,GetAllProductsGateway>(configureHttpClient);
        return services;
    }
}
