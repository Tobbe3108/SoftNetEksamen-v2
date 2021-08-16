using System;
using WebAPI.Core.Entities;

namespace WebAPI.Features.Rentals
{
  public record Rental : TableBase
  {
    public Guid ContainerId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime Rented { get; set; }
    public DateTime? Returned { get; set; }
  }
}