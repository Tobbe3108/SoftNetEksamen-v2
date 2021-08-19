using System;
using ServiceStack.DataAnnotations;
using WebAPI.Core.Entities;

namespace WebAPI.Features.Customer
{
  [Alias("Customer")]
  public record Table : TableBase
  {
    [ForeignKey(typeof(ContactPerson.Table)), Required]
    public Guid ContactPersonId { get; set; }

    [Required] public string? Address { get; set; }
    [Required] public string? Cvr { get; set; }
    [Required] public string? Mail { get; set; }
  }
}