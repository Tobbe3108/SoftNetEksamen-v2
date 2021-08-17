using Microsoft.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace
namespace WebAPI.Features.Container.Endpoints
{
  [Controller]
  [Route("[controller]")]
  public partial class ContainerController : ControllerBase
  {
    private readonly ContainerRepository _repository;

    public ContainerController(ContainerRepository repository)
    {
      _repository = repository;
    }
  }
}
