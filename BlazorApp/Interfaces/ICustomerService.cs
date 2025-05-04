using CustomerModel = BlazorApp.Shared.Models.Customer;

namespace BlazorApp.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerModel>> GetCustomersAsync();
    Task<CustomerModel> GetCustomerAsync(int id);
    Task AddCustomerAsync(CustomerModel customer);
    Task<CustomerModel> UpdateCustomerAsync(CustomerModel customer);
    Task DeleteCustomerAsync(int id);
}