using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Interfaces;

// ReSharper disable once CheckNamespace
namespace WebAPI.Features.ContactPerson.Endpoints
{
  [Controller]
  [Route("[controller]")]
  public partial class ContactPersonController : ControllerBase
  {
    private readonly BaseRepository<Table> _repository;

    public ContactPersonController(BaseRepository<Table> repository)
    {
      _repository = repository;
    }
  }
}