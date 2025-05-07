using BlazorApp.Models;

namespace BlazorApp.Interfaces;

/// <summary>
/// This interface defines the contract for customer-related operations.
/// - Get all customers
/// - Get a customer by ID
/// - Create a new customer
/// - Update an existing customer
/// - Delete a customer
/// </summary>
public interface ICustomerService
{
    Task AddCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerAsync(int id);
    Task UpdateCustomerAsync(Customer customer);
    Task<bool> DeleteCustomerAsync(int id);
}