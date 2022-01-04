using eCommerce.Application.Interfaces;
using eCommerce.Persistence.Repositories;
using eCommerce.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Persistence;

public static class ConfigureServices
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<eCommerceContext>(options =>
            options.UseSqlServer(connectionString)
        );

        services.AddScoped<DbContext, eCommerceContext>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(EfUnitOfWork));


        #region .::Repositories::.

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryTranslationRepository, CategoryTranslationRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<ISubCategoryTranslationRepository, SubCategoryTranslationRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
        services.AddScoped<IOrderStatusTranslationRepository, OrderStatusTranslationRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductTranslationRepository, ProductTranslationRepository>();


        #endregion

        return services;
    }
}
