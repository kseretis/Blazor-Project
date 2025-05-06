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
            AllowedGrantTypes = GrantTypes.Code,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = {"read", "write", "delete"},
        }
    };
}

public static class ApiScopes
{
    public static IEnumerable<ApiScope> Get() => new List<ApiScope>
    {
        new ("read", "Read access to API"),
        new ("write", "Write access to API"),
        new ("delete", "Delete access to API")
    };
}

public static class ApiResources
{
    public static IEnumerable<ApiResource> Get() => new List<ApiResource>
    {
        new ("api", "BlazorApp API") { Scopes = { "read", "write", "delete" } }
    };
}

public static class IdentityResources
{
    public static IEnumerable<IdentityResource> Get() => new List<IdentityResource>
    {
        new DIdentityResources.OpenId(),
        new DIdentityResources.Profile(),
    };
}