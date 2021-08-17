using System;
using ServiceStack.DataAnnotations;
using WebAPI.Core.Entities;

namespace WebAPI.Features.Container
{
  public record Table : TableBase
  {
    [Required] public int Shelves { get; set; }
    [Required] public DateTime Rented { get; set; }
  }
}