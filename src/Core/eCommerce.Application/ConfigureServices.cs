using eCommerce.Application.Services;
using eCommerce.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;

namespace eCommerce.Application;

public static class ConfigureServices
{

    public static IServiceCollection AddCore(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        #region .::Services::.

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryTranslationService, CategoryTranslationService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<ISubCategoryService, SubCategoryService>();
        services.AddScoped<ISubCategoryTranslationService, SubCategoryTranslationService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IOrderStatusService, OrderStatusService>();
        services.AddScoped<IOrderStatusTranslationService, OrderStatusTranslationService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductTranslationService, ProductTranslationService>();


        #endregion

        return services;
    }
}
