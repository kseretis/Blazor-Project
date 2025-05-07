using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Client.Services;

/// <summary>
/// This class is responsible for obtaining and managing the access token used for authentication.
/// </summary>
public class TokenService
{
    private const string TokenEndpointSuffix = "connect/token";
    
    // The following variables are used to store the configuration values for the token service.
    // These values are stored in a secrets.json file.
    private string ClientId => _configuration["TokenService:ClientId"]!;
    private string ClientSecret => _configuration["TokenService:ClientSecret"]!;
    private string Scope => _configuration["TokenService:Scope"]!;
    
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    
    private string? AccessToken { get; set; }

    public TokenService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        if (AccessToken is not null)
        {
            return AccessToken;
        }
        
        var content = new StringContent(
            $"grant_type=client_credentials&client_id={ClientId}&client_secret={ClientSecret}&scope={Scope}",
            Encoding.UTF8,
            "application/x-www-form-urlencoded");
        
        var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}{TokenEndpointSuffix}", content);

        var responseContent = await response.Content.ReadAsStringAsync();
        
        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);
            return AccessToken = tokenResponse?.AccessToken;
        }
        
        Console.WriteLine($"Error getting token: {response.StatusCode} - {responseContent}");
        return null;
    }

    private class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
    }
}
