using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Container.Endpoints
{
  public partial class ContainerController
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
    public int Shelves { get; set; }
    public DateTime Rented { get; set; }
  }
}