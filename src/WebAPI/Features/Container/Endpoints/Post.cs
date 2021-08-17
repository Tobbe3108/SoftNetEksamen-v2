using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Container.Endpoints
{
  public partial class ContainerController
  {
    [HttpPost]
    public async Task<Table?> CreateAsync([FromBody] PostRequest request)
    {
      return await _repository.CreateAsync(request.Adapt<Table>());
    }
  }

  public record PostRequest
  {
    public int Shelves { get; set; }
    public DateTime Rented { get; set; }
  }
}