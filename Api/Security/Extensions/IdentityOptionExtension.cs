using Api.Security.Services;
using API.Security.Services;
using Domain.Security;
using Infrastructure.Data.DataBaseContext;

namespace Api.Security.Extensions;

public static class IdentityOptionExtension
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<CustomIdentityUser>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication();

        services.AddScoped<IJwtSecurityService, JwtSecurityService>();

        return services;
    }
}
