using BlazorApp.Models;
using BlazorApp.Shared.Dtos;

namespace BlazorApp.Extensions;

/// <summary>
/// This class contains extension methods for converting between Customer and CustomerDto.
/// </summary>
public static class CustomerExtensions
{
    public static Customer ToCustomer(this CustomerDto customerModelDto)
    {
        var customer = new Customer
        {
            CompanyName = customerModelDto.CompanyName,
            ContactName = customerModelDto.ContactName,
            Address = customerModelDto.Address,
            City = customerModelDto.City,
            Region = customerModelDto.Region,
            PostalCode = customerModelDto.PostalCode,
            Country = customerModelDto.Country,
            Phone = customerModelDto.Phone
        };

        if (customerModelDto.Id.HasValue)
        {
            customer.Id = customerModelDto.Id.Value;
        }

        return customer;
    }
    
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            CompanyName = customer.CompanyName,
            ContactName = customer.ContactName,
            Address = customer.Address,
            City = customer.City,
            Region = customer.Region,
            PostalCode = customer.PostalCode,
            Country = customer.Country,
            Phone = customer.Phone
        };
    }

    public static IEnumerable<CustomerDto> ToCustomerDtoList(this IEnumerable<Customer> customers)
    {
        return customers.Select(c => c.ToCustomerDto());
    }
    
    public static IEnumerable<Customer> ToCustomerList(this IEnumerable<CustomerDto> customers)
    {
        return customers.Select(c => c.ToCustomer());
    }
}