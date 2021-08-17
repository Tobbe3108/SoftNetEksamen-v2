using System;
using ServiceStack.DataAnnotations;

namespace WebAPI.Core.Entities
{
  public abstract record TableBase
  {
    [PrimaryKey, Required, AutoId] public Guid? Id { get; set; }
  }
}