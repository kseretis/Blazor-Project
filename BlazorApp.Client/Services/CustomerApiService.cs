using System.Net.Http.Headers;
using System.Net.Http.Json;
using BlazorApp.Shared.Dtos;

namespace BlazorApp.Client.Services;

public class CustomerApiService
{
    private const string ApiPrefixUrl = "api/";
    private const string CustomerApiSuffix = "Customer";

    private readonly ILogger<CustomerApiService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly TokenService _tokenService;
    
    public CustomerApiService(IHttpClientFactory httpClientFactory, TokenService tokenService, ILogger<CustomerApiService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
        _logger = logger;
    }
    
    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        var httpClient = await CreateHttpClient();
        
        return await httpClient.GetFromJsonAsync<IEnumerable<CustomerDto>>(
            $"{httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}") ?? [];
    }

    public async Task<CustomerDto?> GetCustomerAsync(string id)
    {
        var httpClient = await CreateHttpClient();

        return await httpClient.GetFromJsonAsync<CustomerDto>($"{httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");
    }
    
    public async Task<bool> AddCustomerAsync(CustomerDto customerDto)
    {
        var httpClient = await CreateHttpClient();
        
        var response = await httpClient.PostAsJsonAsync($"{httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}", customerDto);

        return response.IsSuccessStatusCode;
    }
    
    public async Task UpdateCustomerAsync(CustomerDto customer)
    {
        var httpClient = await CreateHttpClient();
        
        var response = await httpClient.PutAsJsonAsync($"{httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}", customer);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
    
    public async Task DeleteCustomerAsync(int id)
    {
        var httpClient = await CreateHttpClient();

        var response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }

    private async Task<HttpClient> CreateHttpClient()
    {
        var httpClient = _httpClientFactory.CreateClient("MyHttpClient");
        
        await SetupBearerAccessToken(httpClient);
        
        return httpClient;
    }
    
    
    private async Task SetupBearerAccessToken(HttpClient httpClient)
    {
        var token = await _tokenService.GetAccessTokenAsync();
        if (token is not null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}