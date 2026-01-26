using AppStore.Backend.Controllers.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //Categories Controllers
        app.UseCreateCategoryController();


        //Suppliers Controllers
        app.UseCreateSupplierController();

        //Stocks Controllers
        app.UseUpdateStockController();

        return app;


    }
}
