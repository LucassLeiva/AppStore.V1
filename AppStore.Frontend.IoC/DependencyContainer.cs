using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddAppStoreServices(
    this IServiceCollection services,
    Action<HttpClient> configureHttpClient)
    {
        services.AddWebApiGateways(configureHttpClient)
        .AddViewsServices();
        return services;
    }
}