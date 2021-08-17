using System;
using ServiceStack.DataAnnotations;
using WebAPI.Core.Entities;

namespace WebAPI.Features.Rental
{
  public record Table : TableBase
  {
    [ForeignKey(typeof(Container.Table)), Required]
    public Guid ContainerId { get; set; }

    [ForeignKey(typeof(Customer.Table)), Required]
    public Guid CustomerId { get; set; }

    [Required] public DateTime Rented { get; set; }
    public DateTime? Returned { get; set; }
  }
}