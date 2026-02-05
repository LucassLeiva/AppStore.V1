namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways(this IServiceCollection services, Action<HttpClient> configureHttpClient)
    {
        services.AddHttpClient<ICreateProductGateway,CreateProductGateway>(configureHttpClient);
        services.AddHttpClient<IGetAllProductsGateway,GetAllProductsGateway>(configureHttpClient);
        services.AddHttpClient<IGetProductByIdGateway, GetProductByIdGateway>(configureHttpClient);
        services.AddHttpClient<IUpdateProductGateway, UpdateProductGateway>(configureHttpClient);
        services.AddHttpClient<IDeleteProductGateway, DeleteProductGateway>(configureHttpClient);
        services.AddHttpClient<IActivateProductGateway, ActivateProductGateway>(configureHttpClient);




        services.AddHttpClient<IUpdateStockGateway,UpdateStockGateway>(configureHttpClient);
        services.AddHttpClient<IGetAllCategoriesGateway, GetAllCategoriesGateway>(configureHttpClient);
        services.AddHttpClient<IGetAllSuppliersGateway, GetAllSuppliersGateway>(configureHttpClient);

        return services;
    }
}
