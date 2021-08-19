using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using WebAPI.Core.Entities;

namespace WebAPI.Core.Base
{
  public class BaseRepository<T> where T : TableBase, new()
  {
    private readonly IDbConnectionFactory _dbFactory;

    public BaseRepository(IDbConnectionFactory dbFactory)
    {
      _dbFactory = dbFactory;
    }

    public async Task<T?> CreateAsync(T value)
    {
      using var db = await _dbFactory.OpenAsync();
      await db.InsertAsync(value);
      return value;
    }

    public async Task<List<T>> GetAllAsync()
    {
      using var db = await _dbFactory.OpenAsync();
      return await db.SelectAsync<T>();
    }

    public async Task<T?> GetAsync(Guid id)
    {
      using var db = await _dbFactory.OpenAsync();
      return await db.SingleByIdAsync<T>(id);
    }

    public async Task<int> UpdateAsync(T value)
    {
      using var db = await _dbFactory.OpenAsync();
      return await db.UpdateAsync(value);
    }

    public async Task<int> DeleteAsync(Guid id)
    {
      using var db = await _dbFactory.OpenAsync();
      return await db.DeleteByIdAsync<T>(id);
    }
  }
}