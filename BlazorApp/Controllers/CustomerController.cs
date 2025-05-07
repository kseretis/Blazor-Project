using BlazorApp.Interfaces;
using BlazorApp.Shared.Dtos;
using BlazorApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers;

/// <summary>
/// This class is a controller for managing customers. It is responsible for handling HTTP requests related to customers.
/// It is secured with authorization.
/// </summary>
[Authorize]
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
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomersAsync()
    {
        try
        {
            var customers = await _customerService.GetCustomersAsync();
            
            if (customers.Any())
            {
                return Ok(customers.ToCustomerDtoList());
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
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        try
        {
            var customer = await _customerService.GetCustomerAsync(id);
    
            if (customer is not null)
            {
                return Ok(customer.ToCustomerDto());
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