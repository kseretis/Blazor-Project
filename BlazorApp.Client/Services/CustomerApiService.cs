using System.Net.Http.Json;
using BlazorApp.Shared.Models;
using CustomerModel = BlazorApp.Shared.Models.Customer;

namespace BlazorApp.Client.Services;

public class CustomerApiService
{
    private const string ApiUrl = "http://localhost:5217/api"; // TODO replace with base url   
    private const string CustomerApiSuffix = "/Customer";
    private readonly HttpClient _httpClient;

    public CustomerApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<CustomerModel>?> GetCustomersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerModel>>($"{ApiUrl}{CustomerApiSuffix}");
    }

    public async Task<CustomerModel?> GetCustomerAsync(string id)
    {
        return await _httpClient.GetFromJsonAsync<CustomerModel>($"{ApiUrl}{CustomerApiSuffix}/{id}");
    }
    
    public async Task AddCustomerAsync(CustomerModel customer)
    {
        var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}{CustomerApiSuffix}", customer);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
        
    }
    
    public async Task UpdateCustomerAsync(CustomerModel customer)
    {
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}{CustomerApiSuffix}", customer);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
    
    public async Task DeleteCustomerAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}{CustomerApiSuffix}/{id}");

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        
        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
    }
}