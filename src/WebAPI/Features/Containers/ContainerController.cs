﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Containers
{
  [Controller]
  [Route("[controller]")]
  public class ContainerController : ControllerBase
  {
    private readonly BaseRepository<Container> _repository;

    public ContainerController(BaseRepository<Container> repository)
    {
      _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]Container container)
    {
      var result = await _repository.CreateAsync(container);
      return result > 0 ? new OkObjectResult(container) : Conflict();
    }

    [HttpGet("{id:guid}")]
    public async Task<Container?> GetAsync([FromRoute]Guid id)
    {
      return await _repository.GetAsync(id);
    }

    [HttpGet]
    public async Task<List<Container>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync([FromBody]Container container)
    {
      var result = await _repository.UpdateAsync(container);
      return result > 0 ? new OkObjectResult(container) : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
      var result = await _repository.DeleteAsync(id);
      return result > 0 ? NoContent() : NotFound();
    }
  }
}