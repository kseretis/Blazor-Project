using CustomerModel = BlazorApp.Shared.Models.Customer;

namespace BlazorApp.Interfaces;

public interface ICustomerService
{
    Task AddCustomerAsync(CustomerModel customer);
    Task<IEnumerable<CustomerModel>> GetCustomersAsync();
    Task<CustomerModel?> GetCustomerAsync(int id);
    Task UpdateCustomerAsync(CustomerModel customer);
    Task<bool> DeleteCustomerAsync(int id);
}