using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models;

/// <summary>
/// This class represents a customer entity. It is mapped to the "Customers" table in the database.
/// </summary>
[Table("Customers")]
public class Customer
{
    /// <summary>
    /// The Id changed from string to integer to autogenerate the Id when a new customer is created.
    /// </summary>
    [Key]
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? ContactName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    
}
