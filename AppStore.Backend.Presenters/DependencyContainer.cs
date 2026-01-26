using AppStore.Backend.BusinessObjects.Interfaces.CreateCategory;
using AppStore.Backend.BusinessObjects.Interfaces.CreateSupplier;
using AppStore.Backend.BusinessObjects.Interfaces.Products.CreateProduct;
using AppStore.Backend.BusinessObjects.Interfaces.Products.DeleteProduct;
using AppStore.Backend.BusinessObjects.Interfaces.Products.UpdateProduct;
using AppStore.Backend.BusinessObjects.Interfaces.Stocks.UpdateStock;
using AppStore.Backend.Presenters.CreateCategory;
using AppStore.Backend.Presenters.CreateSupplier;
using AppStore.Backend.Presenters.Products.CreateProduct;
using AppStore.Backend.Presenters.Products.DeleteProduct;
using AppStore.Backend.Presenters.Products.GetAllProducts;
using AppStore.Backend.Presenters.Products.GetProductById;
using AppStore.Backend.Presenters.Products.UpdateProduct;
using AppStore.Backend.Presenters.Stock.UpdateStock;

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

        //Servicios de Categories
        services.AddScoped<ICreateCategoryOutputPort, CreateCategoryPresenter>();

        //Servucuis de Stocks
        services.AddScoped<IUpdateStockOutputPort, UpdateStockPresenter>();


        //Servicios de Suppliers
        services.AddScoped<ICreateSupplierOutputPort, CreateSupplierPresenter>();
        return services;
    }
}
