using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, CompanyName = "Acme Corp", ContactName = "John Doe", Address = "123 Elm St", 
                City = "Metropolis", Region = "NA", PostalCode = "12345", Country = "USA", Phone = "555-1234" },
            new Customer { Id = 2, CompanyName = "Globex Inc", ContactName = "Jane Smith", Address = "456 Oak St", 
                City = "Springfield", Region = "NA", PostalCode = "67890", Country = "USA", Phone = "555-5678" },
            new Customer { Id = 3, CompanyName = "Initech", ContactName = "Bill Lumbergh", Address = "789 Pine St", 
                City = "Capital City", Region = "NA", PostalCode = "11223", Country = "USA", Phone = "555-9012" },
            new Customer { Id = 4, CompanyName = "Umbrella Corp", ContactName = "Alice Abernathy", Address = "321 Maple St", 
                City = "Raccoon City", Region = "NA", PostalCode = "44556", Country = "USA", Phone = "555-3456" },
            new Customer { Id = 5, CompanyName = "Wayne Enterprises", ContactName = "Bruce Wayne", Address = "654 Cedar St", 
                City = "Gotham", Region = "NA", PostalCode = "77889", Country = "USA", Phone = "555-7890" }
        );
    }
}