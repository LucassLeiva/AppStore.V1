using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Backend.Presenters.CreateCategory;
using AppStore.Backend.Presenters.CreateSupplier;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(
    this IServiceCollection services)
    {
        services.AddScoped<ICreateProductOutputPort,CreateProductPresenter>();
        services.AddScoped<ICreateCategoryOutputPort, CreateCategoryPresenter>();
        services.AddScoped<ICreateSupplierOutputPort, CreateSupplierPresenter>();
        return services;
    }
}
