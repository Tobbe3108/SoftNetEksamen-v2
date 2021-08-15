using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Containers
{
  [Controller]
  [Route("[controller]")]
  public class ContainerController : ControllerBase
  {
    private readonly IContainerService _containerService;

    public ContainerController(IContainerService containerService)
    {
      _containerService = containerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]Container container)
    {
      var result = await _containerService.CreateAsync(container);
      return result > 0 ? new OkObjectResult(container) : Conflict();
    }

    [HttpGet("{id:guid}")]
    public async Task<Container?> GetAsync([FromRoute]Guid id)
    {
      return await _containerService.GetAsync(id);
    }

    [HttpGet]
    public async Task<List<Container>> GetAllAsync()
    {
      return await _containerService.GetAllAsync();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync([FromBody]Container container)
    {
      var result = await _containerService.UpdateAsync(container);
      return result > 0 ? new OkObjectResult(container) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
      var result = await _containerService.DeleteAsync(id);
      return result > 0 ? NoContent() : NotFound();
    }
  }
}