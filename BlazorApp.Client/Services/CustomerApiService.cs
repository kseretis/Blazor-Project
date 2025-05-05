using System.Net.Http.Json;
using BlazorApp.Shared.Dtos;


namespace BlazorApp.Client.Services;

public class CustomerApiService
{
    private const string ApiPrefixUrl = "api/";
    private const string CustomerApiSuffix = "Customer";

    private readonly ILogger<CustomerApiService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient HttpClient => _httpClientFactory.CreateClient("MyHttpClient");
    private string BaseUrl => HttpClient.BaseAddress!.ToString();
    
    public CustomerApiService(IHttpClientFactory httpClientFactory, ILogger<CustomerApiService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }
    
    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
    {
        return await HttpClient.GetFromJsonAsync<IEnumerable<CustomerDto>>(
            $"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}") ?? [];
    }

    public async Task<CustomerDto?> GetCustomerAsync(string id)
    {
        return await HttpClient.GetFromJsonAsync<CustomerDto>($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");
    }
    
    public async Task<bool> AddCustomerAsync(CustomerDto customerDto)
    {
        var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}", customerDto);

        return response.IsSuccessStatusCode;
    }
    
    public async Task UpdateCustomerAsync(CustomerDto customer)
    {
        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}", customer);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
    
    public async Task DeleteCustomerAsync(int id)
    {
        var response = await HttpClient.DeleteAsync($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
}