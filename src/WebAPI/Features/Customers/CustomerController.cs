using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Customers
{
  [Controller]
  [Route("[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly BaseRepository<Customer> _repository;

    public CustomerController(BaseRepository<Customer> repository)
    {
      _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Customer container)
    {
      var result = await _repository.CreateAsync(container);
      return result > 0 ? new OkObjectResult(container) : Conflict();
    }

    [HttpGet("{id:guid}")]
    public async Task<Customer?> GetAsync([FromRoute] Guid id)
    {
      return await _repository.GetAsync(id);
    }

    [HttpGet]
    public async Task<List<Customer>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync([FromBody] Customer container)
    {
      var result = await _repository.UpdateAsync(container);
      return result > 0 ? new OkObjectResult(container) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
      var result = await _repository.DeleteAsync(id);
      return result > 0 ? NoContent() : NotFound();
    }
  }
}