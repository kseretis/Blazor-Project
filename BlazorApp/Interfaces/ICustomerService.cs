using BlazorApp.Models;

namespace BlazorApp.Interfaces;

public interface ICustomerService
{
    Task AddCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerAsync(int id);
    Task UpdateCustomerAsync(Customer customer);
    Task<bool> DeleteCustomerAsync(int id);
}