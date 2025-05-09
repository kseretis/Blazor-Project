using BlazorApp.Client.Services;
using BlazorApp.Data;
using BlazorApp.Interfaces;
using BlazorApp.Repositories;
using BlazorApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Configurations;

/// <summary>
/// This class contains configuration methods for the Blazor application.
/// </summary>
public static class ProgramConfig
{
    public static string GetBaseUrl(this ConfigurationManager configuration)
    {
        return configuration["ASPNETCORE_URLS"]!;
    }

    public static void ConfigureIdentityServer(this IServiceCollection services)
    {
        services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryClients(Clients.Get())
            .AddInMemoryApiScopes(ApiScopes.Get())
            .AddInMemoryApiResources(ApiResources.Get())
            // .AddInMemoryIdentityResources(IdentityResources.Get())
            .AddTestUsers(TestUsers.Users);
    }

    public static void ConfigureApiSecurity(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration.GetBaseUrl();
                options.Audience = "api";
                options.RequireHttpsMetadata = false;
            });

        services.AddAuthorization();
    }

    public static void ConfigureDatabase(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<CustomerRepository>();
    }

    public static void ConfigureFrontendServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddHttpClient<TokenService>(client => client.BaseAddress = new Uri(configuration.GetBaseUrl()));
        services.AddHttpClient<CustomerApiService>(client => client.BaseAddress = new Uri(configuration.GetBaseUrl()));
    }

    public static void ConfigureBackendServices(this IServiceCollection services)
    {
        services.AddSingleton<WeatherForecastService>();
        services.AddScoped<ICustomerService, CustomerService>();
    }
}
