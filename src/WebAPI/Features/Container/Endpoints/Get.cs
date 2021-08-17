using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Container.Endpoints
{
  public partial class ContainerController
  {
    [HttpGet("{customerId:guid}")]
    public async Task<Table?> GetAsync([FromRoute] Guid id)
    {
      return await _repository.GetAsync(id);
    }

    [HttpGet]
    public async Task<List<Table>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }

    [HttpGet("available")]
    public async Task<List<Table>> GetAllAvailableAsync()
    {
      return await _repository.GetAllAvailableAsync();
    }
  }
}