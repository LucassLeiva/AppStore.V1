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
        app.UseCreateCategoryController();
        app.UseCreateProductController();
        app.UseCreateSupplierController();
        

        return app;


    }
}
