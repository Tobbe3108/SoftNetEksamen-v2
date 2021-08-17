using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Interfaces;

// ReSharper disable once CheckNamespace
namespace WebAPI.Features.Customer.Endpoints
{
  [Controller]
  [Route("[controller]")]
  public partial class CustomerController : ControllerBase
  {
    private readonly BaseRepository<Table> _repository;

    public CustomerController(BaseRepository<Table> repository)
    {
      _repository = repository;
    }
  }
}