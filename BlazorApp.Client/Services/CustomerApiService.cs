using System.Net.Http.Headers;
using System.Net.Http.Json;
using BlazorApp.Shared.Dtos;

namespace BlazorApp.Client.Services;

/// <summary>
/// This class is responsible for making API calls related to customers.
/// </summary>
public class CustomerApiService
{
    private const string ApiPrefixUrl = "api/";
    private const string CustomerApiSuffix = "Customer";
    
    private readonly HttpClient _httpClient;
    private readonly TokenService _tokenService;
    
    public CustomerApiService(HttpClient httpClient, TokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }
    
    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        await SetupBearerAccessToken();
        
        return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerDto>>(
            $"{_httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}") ?? [];
    }

    public async Task<CustomerDto?> GetCustomerAsync(string id)
    {
        await SetupBearerAccessToken();

        return await _httpClient.GetFromJsonAsync<CustomerDto>($"{_httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");
    }
    
    public async Task<bool> AddCustomerAsync(CustomerDto customerDto)
    {
        await SetupBearerAccessToken();
        
        var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}", customerDto);

        return response.IsSuccessStatusCode;
    }
    
    public async Task UpdateCustomerAsync(CustomerDto customer)
    {
        await SetupBearerAccessToken();
        
        var response = await _httpClient.PutAsJsonAsync($"{_httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}", customer);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
    
    public async Task DeleteCustomerAsync(int id)
    {
        await SetupBearerAccessToken();

        var response = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
    
    /// <summary>
    /// This method sets up the Bearer token for authorization in the HTTP client.
    /// Not the best approach, but it works for our case.
    /// </summary>
    private async Task SetupBearerAccessToken()
    {
        var token = await _tokenService.GetAccessTokenAsync();
        if (token is not null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}