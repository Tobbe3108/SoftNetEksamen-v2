using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Rental
{
  public class Repository : BaseRepository<Table>
  {
    private readonly IDbConnectionFactory _dbFactory;

    public Repository(IDbConnectionFactory dbFactory) : base(dbFactory)
    {
      _dbFactory = dbFactory;
    }

    public async Task<List<Table>> GetActiveRentalsAsync(Guid? customerId)
    {
      using var db = await _dbFactory.OpenAsync();
      var expression = db.From<Table>().Where(rental => rental.Returned == null);
      
      if (customerId is not null)
      {
        expression.Where(rental => rental.CustomerId == customerId);
      }
      
      return await db.SelectAsync(expression);
    }

    public async Task<List<Table>> GetReturnedRentalsAsync(Guid? customerId)
    {
      using var db = await _dbFactory.OpenAsync();
      var expression = db.From<Table>().Where(rental => rental.Returned != null);

      if (customerId is not null)
      {
        expression.Where(rental => rental.CustomerId == customerId);
      }

      return await db.SelectAsync(expression);
    }
    
    public new async Task<Table> CreateAsync(Table value)
    {
      using var db = await _dbFactory.OpenAsync();
      var rental = await db.SingleAsync<Table>(table => table.ContainerId == value.ContainerId);
      if (rental is not null) throw new NotSupportedException($"Container with id: {rental.ContainerId} is already rented by customer: {rental.CustomerId}");
      await db.InsertAsync(value);
      return value;
    }
  }
}