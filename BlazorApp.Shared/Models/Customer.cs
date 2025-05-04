using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Shared.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public required string Id { get; init; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
