using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Rental.Endpoints
{
  public partial class RentalController
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
    public Guid ContainerId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime Rented { get; set; }
    public DateTime Returned { get; set; }
  }
}