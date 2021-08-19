using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using WebAPI.Core.Base;

namespace WebAPI.Features.Container
{
  public class ContainerRepository : BaseRepository<Table>
  {
    private readonly IDbConnectionFactory _dbFactory;

    public ContainerRepository(IDbConnectionFactory dbFactory) : base(dbFactory)
    {
      _dbFactory = dbFactory;
    }

    public async Task<List<Table>> GetAllAvailableAsync()
    {
      using var db = await _dbFactory.OpenAsync();
      var test = db.From<Table>()
        .LeftJoin<Rental.Table>((container, rental) => container.Id == rental.ContainerId)
        .Where<Rental.Table>(rental => rental.Id == null);
      return await db.SelectAsync(test);
    }
  }
}