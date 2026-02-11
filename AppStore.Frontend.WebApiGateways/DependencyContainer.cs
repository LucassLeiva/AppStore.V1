namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways(this IServiceCollection services, Action<HttpClient> configureHttpClient)
    {
        services.AddExceptionDelegatingHandler();
        services.AddHttpClient<ICreateProductGateway,CreateProductGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IGetAllProductsGateway,GetAllProductsGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IGetProductByIdGateway, GetProductByIdGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IUpdateProductGateway, UpdateProductGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IDeleteProductGateway, DeleteProductGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IActivateProductGateway, ActivateProductGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();




        services.AddHttpClient<IUpdateStockGateway,UpdateStockGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IGetAllCategoriesGateway, GetAllCategoriesGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddHttpClient<IGetAllSuppliersGateway, GetAllSuppliersGateway>(configureHttpClient).AddHttpMessageHandler<ExceptionDelegatingHandler>();

        return services;
    }
}
