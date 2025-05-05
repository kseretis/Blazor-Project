using BlazorApp.Client.Services;
using BlazorApp.Components;
using BlazorApp.Data;
using BlazorApp.Interfaces;
using BlazorApp.Repositories;
using BlazorApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

services.AddLogging();

ConfigureHttpClient();
ConfigureDatabase();
ConfigureRepositories();
ConfigureServices();

services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.Run();


void ConfigureDatabase()
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

void ConfigureRepositories()
{
    services.AddScoped<CustomerRepository>();
}

void ConfigureHttpClient()
{
    services.AddHttpClient("MyHttpClient", client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["ASPNETCORE_URLS"]!); // localhostUrl
        client.Timeout = TimeSpan.FromSeconds(30);
    });
}

void ConfigureServices()
{
    services.AddSingleton<WeatherForecastService>();
    services.AddScoped<ICustomerService, CustomerService>();
    services.AddScoped<CustomerApiService>();
}

