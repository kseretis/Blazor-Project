using BlazorApp.Interfaces;
using BlazorApp.Shared.Models;

namespace BlazorApp.Services;

public class CustomerService : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await GetCustomersDummy();
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCustomerAsync(int id)
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