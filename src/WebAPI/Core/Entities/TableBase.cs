using System;
using SQLite;

namespace WebAPI.Core.Entities
{
  public abstract record TableBase
  {
    [PrimaryKey, AutoIncrement]
    public Guid Id { get; set; }
  }
}