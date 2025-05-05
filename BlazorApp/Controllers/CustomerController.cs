using BlazorApp.Interfaces;
using BlazorApp.Shared.Dtos;
using BlazorApp.Shared.Extensions;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CustomerDto customerDto)
    {
        try
        {
            await _customerService.AddCustomerAsync(customerDto.ToCustomer());
            
            return Ok("Customer added successfully!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync()
    {
        try
        {
            var customers = await _customerService.GetCustomersAsync();

            if (customers.Any())
            {
                return Ok(customers);
            }
            
            return NotFound("No customers found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        try
        {
            var customer = await _customerService.GetCustomerAsync(id);
    
            if (customer is not null)
            {
                return Ok(customer);
            }
            
            return NotFound($"Customer with id {id} not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
	
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto)
    {
        try
        {
            await _customerService.UpdateCustomerAsync(customerDto.ToCustomer());
    
            return Ok("Customer updated successfully!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        try
        {
            var response = await _customerService.DeleteCustomerAsync(id);

            if (response)
            {
                return Ok();
            }
            
            return NotFound($"Customer with id {id} not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong!");
            return StatusCode(500, "Something went wrong!");
        }
    }
}