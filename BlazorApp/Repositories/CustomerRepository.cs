using BlazorApp.Data;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Repositories;

public class CustomerRepository
{
    private readonly AppDbContext _dbContext;
    
    public CustomerRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }
}