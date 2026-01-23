namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddAppStoreServices(
    this IServiceCollection services,
    Action<HttpClient> configureHttpClient)
    {
        services.AddWebApiGateways(configureHttpClient)
        .AddViewsServices()
        .AddValidationService()
        .AddValidators();
        return services;
    }
}