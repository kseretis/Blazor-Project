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
        try
        {
            var customers = await customerService.GetCustomersAsync();

            if (customers.Any())
            {
                return Ok(customers);
            }
            
            return NotFound("No customers found");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer(string id)
    {
        try
        {
            var customer = await customerService.GetCustomerAsync(id);

            if (customer is not null)
            {
                return Ok(customer);
            }
            
            return NotFound($"Customer with id {id} not found");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }

    // FIXME
    [HttpPost]
    public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
    {
        try
        {
            await customerService.AddCustomerAsync(customer);

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
    
    // FIXME
    [HttpPut]
    public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer)
    {
        try
        {
            await customerService.UpdateCustomerAsync(customer);

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }

    // FIXME
    [HttpDelete("{id}")]
    public async Task<ActionResult<Customer>> DeleteCustom(string id)
    {
        try
        {
            await customerService.DeleteCustomerAsync(id);
            
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
    
}