using System;
using WebAPI.Core.Entities;

namespace WebAPI.Features.Containers
{
  public record Container : TableBase
  {
    public int Shelves { get; set; }
    public DateTime Rented { get; set; }
  }
}