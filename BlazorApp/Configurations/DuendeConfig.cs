using Duende.IdentityServer.Models;
using DClient = Duende.IdentityServer.Models.Client;
using DIdentityResources = Duende.IdentityServer.Models.IdentityResources;

namespace BlazorApp.Configurations;

public static class Clients
{
    public static IEnumerable<DClient> Get() => new List<DClient>
    {
        new DClient
        {
            ClientId = "blazor-app",
            ClientName = "Blazor App",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = {"api"},
        }
    };
}

public static class ApiScopes
{
    public static IEnumerable<ApiScope> Get() => new List<ApiScope>
    {
        new ("api", "Access to API"),
    };
}

public static class ApiResources
{
    public static IEnumerable<ApiResource> Get() => new List<ApiResource>
    {
        new ("api", "BlazorApp API") { Scopes = { "api" } }
    };
}
