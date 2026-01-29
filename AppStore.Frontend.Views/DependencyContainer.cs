using AppStore.Frontend.Views.ViewModels.Product.CreateProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddViewsServices(
    this IServiceCollection services)
    {
        services.AddScoped<CreateProductViewModel>();
        services.AddScoped<GetAllProductsViewModel>();



        //Servicio de Validacion del ViewModel
        services.AddModelValidator<CreateProductViewModel, CreateProductViewModelValidator>();
        

        return services;
    }
       
}
