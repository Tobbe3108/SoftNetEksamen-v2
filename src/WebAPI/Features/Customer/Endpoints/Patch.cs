using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Customer.Endpoints
{
  public partial class CustomerController
  {
    [HttpPatch]
    public async Task<IActionResult> UpdateAsync([FromBody] PatchRequest request)
    {
      var result = await _repository.UpdateAsync(request.Adapt<Table>());
      return result > 0 ? new OkObjectResult(request) : NotFound();
    }
  }

  public record PatchRequest
  {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Cvr { get; set; }
    public string? Mail { get; set; }
  }
}