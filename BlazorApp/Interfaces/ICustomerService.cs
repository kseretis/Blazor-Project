using CustomerModel = BlazorApp.Shared.Models.Customer;

namespace BlazorApp.Interfaces;

public interface ICustomerService
{
    Task AddCustomerAsync(CustomerModel customer);
    Task<IEnumerable<CustomerModel>> GetCustomersAsync();
    Task<CustomerModel?> GetCustomerAsync(string id);
    Task<CustomerModel> UpdateCustomerAsync(CustomerModel customer);
    Task DeleteCustomerAsync(string id);
}