using System.Net.Http.Json;
using BlazorApp.Shared.Models;
using CustomerModel = BlazorApp.Shared.Models.Customer;

namespace BlazorApp.Client.Services;

public class CustomerApiService
{
    private const string ApiUrl = "https://localhost:5001/";
    private readonly HttpClient _httpClient;

    public CustomerApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<IEnumerable<CustomerModel>?> GetCustomersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerModel>>($"{ApiUrl}customers");
    }

    public async Task<IEnumerable<Resp>> GetData()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Resp>>("https://api.restful-api.dev/objects");
    }
}