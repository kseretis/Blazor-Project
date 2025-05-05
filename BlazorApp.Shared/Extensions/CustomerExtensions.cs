using BlazorApp.Shared.Dtos;
using BlazorApp.Shared.Models;

namespace BlazorApp.Shared.Extensions;

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
}