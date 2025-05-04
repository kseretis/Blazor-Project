using BlazorApp.Interfaces;
using BlazorApp.Repositories;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

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
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _customerRepository.GetAllCustomersAsync();
    }

    public async Task<Customer?> GetCustomerAsync(string id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCustomerAsync(string id)
    {
        throw new NotImplementedException();
    }

    private static async Task<IEnumerable<Customer>> GetCustomersDummy()
    {
        await Task.Delay(500);
        
        return Enumerable.Range(1, 5).Select(index => new Customer()
        {
            Id = index.ToString(),
            CompanyName = "Company" + index,
            ContactName = "Contact" + index,
            Address = "Address" + index,
            City = "City" + index,
            Region = "Region" + index,
            PostalCode = "PostalCode" + index,
            Country = "Country" + index,
            Phone = "Phone" + index

        });
    }
}