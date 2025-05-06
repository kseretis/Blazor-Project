using BlazorApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<TokenService>();
builder.Services.AddScoped<CustomerApiService>();

await builder.Build().RunAsync();
