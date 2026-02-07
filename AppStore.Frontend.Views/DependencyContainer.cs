using AppStore.Frontend.Views.ViewModels.Product.DeleteProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddViewsServices(
    this IServiceCollection services)
    {
        services.AddScoped<CreateProductViewModel>();
        services.AddScoped<GetAllProductsViewModel>();
        services.AddScoped<UpdateProductViewModel>();
        services.AddScoped<DeleteProductViewModel>();
        services.AddScoped<ActivateProductViewModel>();



        //Servicio de Validacion del ViewModel
        services.AddModelValidator<CreateProductViewModel, CreateProductViewModelValidator>();
        services.AddModelValidator<UpdateProductViewModel, UpdateProductViewModelValidator>();
        

        return services;
    }
       
}
