using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Rental.Endpoints
{
  public partial class RentalController
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

    [HttpGet("active")]
    public async Task<List<Table>> GetActiveRentals([FromQuery] Guid? customerId = null)
    {
      return await _repository.GetActiveRentalsAsync(customerId);
    }

    [HttpGet("returned")]
    public async Task<List<Table>> GetReturnedRentals([FromQuery] Guid? customerId = null)
    {
      return await _repository.GetReturnedRentalsAsync(customerId);
    }
  }
}