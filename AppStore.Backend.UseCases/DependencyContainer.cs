using AppStore.Backend.UseCases.Products.ActivateProduct;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
        this IServiceCollection services)
        {
             //Servicios de Products
            services.AddScoped<ICreateProductInputPort,CreateProductInteractor>();
            services.AddScoped<IGetAllProductsInputPort, GetAllProductsInteractor>();
            services.AddScoped<IGetProductByIdInputPort, GetProductByIdInteractor>();
            services.AddScoped<IUpdateProductInputPort, UpdateProductInteractor>();
            services.AddScoped<IDeleteProductInputPort,DeleteProductInteractor>();
            services.AddScoped<IActivateProductInputPort,ActivateProductInteractor>();


            //Servicios de Stocks
            services.AddScoped<IUpdateStockInputPort, UpdateStockInteractor>();


           //Servicios de Categories
            services.AddScoped<ICreateCategoryInputPort,CreateCategoryInteractor>();
            services.AddScoped<IGetAllCategoriesInputPort, GetAllCategoriesInteractor>();
            services.AddScoped<IGetCategoryByIdInputPort,GetCategoryByIdInteractor>();
            services.AddScoped<IUpdateCategoryInputPort,UpdateCategoryInteractor>();
            services.AddScoped<IDeleteCategoryInputPort, DeleteCategoryInteractor>();



            //Servicios de Suppliers
            services.AddScoped<ICreateSupplierInputPort,CreateSupplierInteractor>();
            services.AddScoped<IGetAllSuppliersInputPort,GetAllSuppliersInteractor>();
            services.AddScoped<IGetSupplierByIdInputPort,GetSupplierByIdInteractor>();
            services.AddScoped<IUpdateSupplierInputPort, UpdateSupplierInteractor>();
            services.AddScoped<IDeleteSupplierInputPort, DeleteSupplierInteractor>();




        //Servicios de Validacion de Casos de Usos
        services.AddModelValidator<CreateProductDto, CreateProductCategoryValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductSupplierValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductInternalCodeValidator>();

        return services;
        }
    }

