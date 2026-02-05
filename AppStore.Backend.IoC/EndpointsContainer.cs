namespace Microsoft.AspNetCore.Builder;
public static class EndpointsContainer
{
    public static WebApplication MapAppStoreEndpoints(
    this WebApplication app)
    {
        //Products Controllers
        app.UseCreateProductController();
        app.UseGetAllProductsController();
        app.UseGetProductByIdController();
        app.UseUpdateProductController();
        app.UseDeleteProductController();
        app.UseActivateProductController();

        //Categories Controllers
        app.UseCreateCategoryController();
        app.UseGetAllCategoriesController();
        app.UseGetCategoryByIdController();
        app.UseUpdateCategoryController();
        app.UseDeleteCategoryController();


        //Suppliers Controllers
        app.UseCreateSupplierController();
        app.UseGetAllSuppliersController();
        app.UseGetSupplierByIdController();
        app.UseUpdateSupplierController();
        app.UseDeleteSupplierController();

        //Stocks Controllers
        app.UseUpdateStockController();

        return app;


    }
}
