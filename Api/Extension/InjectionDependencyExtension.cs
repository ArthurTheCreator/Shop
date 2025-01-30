using Infrastructure.Application;
using Infrastructure.Application.Service.Category;
using Infrastructure.Application.Service.Product;
using Infrastructure.Interface.Repository;
using Infrastructure.Interface.Service;
using Infrastructure.Interface.UnitOfWOrk;
using Infrastructure.Interface.ValidateService;
using Infrastructure.Mapper;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.UnitOfWork;

namespace Api.Extension;

public static class InjectionDependencyExtension
{
    public static IServiceCollection ConfigureInjectionDependecy(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryValidateService, CategoryValidateService>();
        services.AddScoped<IProductValidateService, ProductValidateService>();
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}