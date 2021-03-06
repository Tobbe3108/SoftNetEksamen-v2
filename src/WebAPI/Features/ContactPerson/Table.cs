using System;
using ServiceStack.DataAnnotations;
using WebAPI.Core.Entities;

namespace WebAPI.Features.ContactPerson
{
  [Alias("ContactPerson")]
  public record Table : TableBase
  {
    [ForeignKey(typeof(Customer.Table))]
    [Required]
    public Guid CustomerId { get; set; }

    [Required] public string? Name { get; set; }
    [Required] public string? JobTitle { get; set; }
    [Required] public string? Mail { get; set; }
    [Required] public string? Phone { get; set; }
  }
}