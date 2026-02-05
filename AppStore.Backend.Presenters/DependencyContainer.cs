namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(
    this IServiceCollection services)
    {
        //Servicios de Products
        services.AddScoped<ICreateProductOutputPort,CreateProductPresenter>();
        services.AddScoped<IGetAllProductsOutputPort,GetAllProductsPresenter>();
        services.AddScoped<IGetProductByIdOutputPort,GetProductByIdPresenter>();
        services.AddScoped<IUpdateProductOutputPort,UpdateProductPresenter>();
        services.AddScoped<IDeleteProductOutputPort,DeleteProductPresenter>();
        services.AddScoped<IActivateProductOutputPort, ActivateProductPresenter>();

        //Servicios de Categories
        services.AddScoped<ICreateCategoryOutputPort, CreateCategoryPresenter>();
        services.AddScoped<IGetAllCategoriesOutputPort,GetAllCategoriesPresenter>();
        services.AddScoped<IGetCategoryByIdOutputPort,GetCategoryByIdPresenter>();   
        services.AddScoped<IUpdateCategoryOutputPort,UpdateCategoryPresenter>();
        services.AddScoped<IDeleteCategoryOutputPort, DeleteCategoryPresenter>();

        //Servucuis de Stocks
        services.AddScoped<IUpdateStockOutputPort, UpdateStockPresenter>();


        //Servicios de Suppliers
        services.AddScoped<ICreateSupplierOutputPort, CreateSupplierPresenter>();
        services.AddScoped<IGetAllSuppliersOutputPort, GetAllSuppliersPresenter>();
        services.AddScoped<IGetSupplierByIdOutputPort, GetSupplierByIdPresenter>();
        services.AddScoped<IUpdateSupplierOutputPort, UpdateSupplierPresenter>();
        services.AddScoped<IDeleteSupplierOutputPort, DeleteSupplierPresenter>();

        return services;
    }
}
