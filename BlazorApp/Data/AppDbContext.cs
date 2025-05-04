using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}