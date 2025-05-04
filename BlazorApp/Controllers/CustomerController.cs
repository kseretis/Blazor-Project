using BlazorApp.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> logger;
    private readonly ICustomerService customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        this.logger = logger;
        this.customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync()
    {
        var customers = await customerService.GetCustomersAsync();
        return Ok(customers);
    }
    
}