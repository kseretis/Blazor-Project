using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Dtos;

/// <summary>
/// This class represents a Data Transfer Object (DTO) for a customer.
/// We avoid using the Entity Framework model directly in the API to prevent exposing the database structure.
/// </summary>
public class CustomerDto
{
    public int? Id { get; set; }
    
    [Required(ErrorMessage = "Company Name is required.")]
    public string? CompanyName { get; set; }

    [Required(ErrorMessage = "Contact Name is required.")]
    public string? ContactName { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public string? Address { get; set; }

    public string? City { get; set; }
    public string? Region { get; set; }
    
    [Required(ErrorMessage = "Post code is required.")]
    public string? PostalCode { get; set; }
    public string? Country { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    public string? Phone { get; set; }
}
