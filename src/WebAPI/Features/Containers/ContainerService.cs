using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Containers
{
  public class ContainerService : IContainerService
  {
    private readonly string _connectionString;

    public ContainerService(string connectionString)
    {
      _connectionString = connectionString;
    }

    public async Task<bool> CreateTableAsync()
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        await asyncConnection.CreateTableAsync<Container>(CreateFlags.AllImplicit);
        return await Task.FromResult(true);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<int> CreateAsync(Container container)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.InsertAsync(container);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<List<Container>> GetAllAsync()
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.Table<Container>().ToListAsync();
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<Container?> GetAsync(Guid id)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        var query = asyncConnection.Table<Container>().Where(s => s.Id == id);
        return await query.FirstOrDefaultAsync();
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<int> UpdateAsync(Container container)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.UpdateAsync(container);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<int> DeleteAsync(Guid id)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.DeleteAsync<Container>(id);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }
  }
}