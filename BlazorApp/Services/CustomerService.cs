using BlazorApp.Interfaces;
using BlazorApp.Repositories;
using BlazorApp.Shared.Models;

namespace BlazorApp.Services;

public class CustomerService : ICustomerService
{
    private readonly CustomerRepository _customerRepository;
    
    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task AddCustomerAsync(Customer customer)
    {
        await _customerRepository.CreateCustomer(customer);
    }
    
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _customerRepository.GetAllCustomersAsync();
    }

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        return await _customerRepository.GetCustomerAsync(id);
    }
    
    public async Task UpdateCustomerAsync(Customer customer)
    {
        await _customerRepository.UpdateCustomerAsync(customer);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetCustomerAsync(id);
        if (customer is null)
        {
            return false;
        }
        
        await _customerRepository.DeleteCustomerAsync(customer);
        return true;
    }
}