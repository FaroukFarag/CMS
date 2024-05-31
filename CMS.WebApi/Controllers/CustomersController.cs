using CMS.Application.Dtos.Customers;
using CMS.Application.Interfaces.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CustomerDto customerDto)
    {
        return Ok(await _service.CreateAsync(customerDto));
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(int id)
    {
        CustomerDto customerDto = await _service.GetAsync(id);

        if (customerDto == null)
            return NotFound();

        return Ok(customerDto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CustomerDto newCustomerDto)
    {
        return Ok(await _service.Update(newCustomerDto));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        CustomerDto customerDto = await _service.Delete(id);

        if (customerDto == null)
            return NotFound();

        return Ok(customerDto);
    }
}
