using System;
using SQLite;

namespace WebAPI.Features.Containers
{
  public record Container
  {
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
    public int Shelves { get; set; }
    public DateTime Rented { get; set; }
  }
}