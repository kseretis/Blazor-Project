using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BlazorApp.Shared.Dtos;
using CustomerModel = BlazorApp.Shared.Models.Customer;

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
    
    public async Task<IEnumerable<CustomerModel>?> GetCustomersAsync()
    {
        return await HttpClient.GetFromJsonAsync<IEnumerable<CustomerModel>>($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}");
    }

    public async Task<CustomerModel?> GetCustomerAsync(string id)
    {
        return await HttpClient.GetFromJsonAsync<CustomerModel>($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}/{id}");
    }
    
    public async Task<bool> AddCustomerAsync(CustomerDto customerDto)
    {
        var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}", customerDto);

        return response.IsSuccessStatusCode;
    }
    
    public async Task UpdateCustomerAsync(CustomerModel customer)
    {
        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}{ApiPrefixUrl}{CustomerApiSuffix}", customer);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
    
    public async Task DeleteCustomerAsync(string id)
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