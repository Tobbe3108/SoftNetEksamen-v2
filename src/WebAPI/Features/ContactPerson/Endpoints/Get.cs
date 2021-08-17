using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.ContactPerson.Endpoints
{
  public partial class ContactPersonController
  {
    [HttpGet("{id:guid}")]
    public async Task<Table?> GetAsync([FromRoute] Guid id)
    {
      return await _repository.GetAsync(id);
    }

    [HttpGet]
    public async Task<List<Table>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }
  }
}