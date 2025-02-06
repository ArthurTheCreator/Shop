using Shop.Web.Services.Interfaces;
using Shop.Web.Services.Service;

namespace Shop.Web.Extension;

public static class InjectionDependencyExtension
{
    public static IServiceCollection ConfigureInjectionDependecy(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
