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
            services.AddScoped<IUpdateProductWithStockInputPort, UpdateProductWithStockInteractor>();
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
        //Servicios de CreateProduct
            services.AddModelValidator<CreateProductDto, CreateProductCategoryValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductSupplierValidator>();
            services.AddModelValidator<CreateProductDto, CreateProductInternalCodeValidator>();

        //Servicios de UpdateProduct
        services.AddModelValidator<UpdateProductDto, UpdateProductCategoryValidator>();
        services.AddModelValidator<UpdateProductDto, UpdateProductSupplierValidator>();
        services.AddModelValidator<UpdateProductDto, UpdateProductInternalCodeValidator>();
        //Servicios de UpdateProductWithStock
        services.AddModelValidator<UpdateProductWithStockDto, UpdateProductWithStockCategoryValidator>();
        services.AddModelValidator<UpdateProductWithStockDto, UpdateProductWithStockSupplierValidator>();
        services.AddModelValidator<UpdateProductWithStockDto, UpdateProductWithStockInternalCodeValidator>();
        services.AddModelValidator<UpdateProductWithStockDto, UpdateProductWithStockProductExistsValidator>();
        //Servicios de DeleteProduct
        services.AddModelValidator<DeleteProductDto, DeleteProductExistsValidator>();
        //Servicios de ActivateProduct
        services.AddModelValidator<ActivateProductDto, ActivateProductExistsValidator>();
        //Servicios de UpdateStock
        services.AddModelValidator<UpdateStockDto, UpdateStockProductExistsValidator>();

        return services;
        }
    }

