using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Backend.UseCases.CreateCategory;
using AppStore.Backend.UseCases.CreateSupplier;

namespace Microsoft.Extensions.DependencyInjection;
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
        this IServiceCollection services)
        {
            services.AddScoped<ICreateProductInputPort,CreateProductInteractor>();
            services.AddScoped<ICreateCategoryInputPort,CreateCategoryInteractor>();
            services.AddScoped<ICreateSupplierInputPort,CreateSupplierInteractor>();

        //Servicios de Validacion de Casos de Usos
            services.AddModelValidator<CreateProductDto, CreateProductCategoryValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductSupplierValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductInternalCodeValidator>();

        return services;
        }
    }

