using AppStore.Frontend.Views.ViewModels.Product.DeleteProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddViewsServices(
    this IServiceCollection services)
    {
        services.AddTransient<CreateProductViewModel>();
        services.AddScoped<GetAllProductsViewModel>();
        services.AddScoped<UpdateProductViewModel>();
        services.AddTransient<DeleteProductViewModel>();
        services.AddTransient<ActivateProductViewModel>();



        //Servicio de Validacion del ViewModel
        services.AddModelValidator<CreateProductViewModel, CreateProductViewModelValidator>();
        services.AddModelValidator<UpdateProductViewModel, UpdateProductViewModelValidator>();
        

        return services;
    }
       
}
