using eCommerce.Application;
using eCommerce.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class ConfigureServices
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }


}
