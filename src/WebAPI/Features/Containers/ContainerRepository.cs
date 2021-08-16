using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Containers
{
  public class ContainerRepository : BaseRepository<Container>
  {
    public ContainerRepository(string connectionString) : base(connectionString)
    {
    }
  }
}