namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddViewsServices(
    this IServiceCollection services)
    {
        services.AddScoped<CreateProductViewModel>();



        //Servicio de Validacion del ViewModel
        services.AddModelValidator<CreateProductViewModel, CreateProductViewModelValidator>();

        return services;
    }
       
}
