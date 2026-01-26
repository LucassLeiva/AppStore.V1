using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct;
using AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProduct;
using AppStore.Backend.UseCases.CreateCategory;
using AppStore.Backend.UseCases.CreateSupplier;
using AppStore.Backend.UseCases.Products.CreateProduct;
using AppStore.Backend.UseCases.Products.DeleteProduct;
using AppStore.Backend.UseCases.Products.GetAllProducts;
using AppStore.Backend.UseCases.Products.GetProductById;
using AppStore.Backend.UseCases.Products.UpdateProduct;
using AppStore.Backend.UseCases.Stocks.UpdateStock;

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


            //Servicios de Stocks
            services.AddScoped<IUpdateStockInputPort, UpdateStockInteractor>();



            services.AddScoped<ICreateCategoryInputPort,CreateCategoryInteractor>();
            services.AddScoped<ICreateSupplierInputPort,CreateSupplierInteractor>();









        //Servicios de Validacion de Casos de Usos
            services.AddModelValidator<CreateProductDto, CreateProductCategoryValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductSupplierValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductInternalCodeValidator>();

        return services;
        }
    }

