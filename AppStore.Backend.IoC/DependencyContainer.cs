namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddAppStoreServices(
    this IServiceCollection services,
    Action<DBOptions> configureDBOptions)
    {
        services.AddUseCasesServices()
        .AddRepositories()
        .AddDataContexts(configureDBOptions)
        .AddPresenters()
        .AddValidationService()
        .AddValidators();
        return services;
    }
}
