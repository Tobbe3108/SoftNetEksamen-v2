using System;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.ContactPerson.Endpoints
{
  public partial class ContactPersonController
  {
    [HttpPost]
    public async Task<Table?> CreateAsync([FromBody] PostRequest request)
    {
      return await _repository.CreateAsync(request.Adapt<Table>());
    }
  }

  public record PostRequest
  {
    public Guid CustomerId { get; set; }
    public string? Name { get; set; }
    public string? JobTitle { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
  }
}