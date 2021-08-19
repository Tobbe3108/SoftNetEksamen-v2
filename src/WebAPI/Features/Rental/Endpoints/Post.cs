using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Rental.Endpoints
{
  public partial class RentalController
  {
    [HttpPost]
    public async Task<Table?> CreateAsync([FromBody] PostRequest request)
    {
      return await _repository.CreateAsync(request.Adapt<Table>());
    }
  }

  public record PostRequest
  {
    public Guid ContainerId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime Rented { get; set; }
    public DateTime? Returned { get; set; }
  }
}