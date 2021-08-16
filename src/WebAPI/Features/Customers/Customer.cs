using WebAPI.Core.Entities;

namespace WebAPI.Features.Customers
{
  public record Customer : TableBase
  {
    public string? Address { get; set; }
    public string? Cvr { get; set; }
    public string? Mail { get; set; }
  }
}