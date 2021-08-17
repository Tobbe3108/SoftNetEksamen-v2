using Microsoft.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace
namespace WebAPI.Features.Rental.Endpoints
{
  [Controller]
  [Route("[controller]")]
  public partial class RentalController : ControllerBase
  {
    private readonly Repository _repository;

    public RentalController(Repository repository)
    {
      _repository = repository;
    }
  }
}