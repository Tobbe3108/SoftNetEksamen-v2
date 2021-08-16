using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using SQLite;
using WebAPI.Core.Entities;

namespace WebAPI.Core.Interfaces
{
  public abstract class BaseRepository<T> where T : TableBase, new()
  {
    private readonly string _connectionString;

    protected BaseRepository(string connectionString)
    {
      _connectionString = connectionString;
      Task.Run(CreateTableAsync).Wait();
    }

    private async Task<bool> CreateTableAsync()
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        await asyncConnection.CreateTableAsync<T>(CreateFlags.AllImplicit);
        return await Task.FromResult(true);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<int> CreateAsync(T value)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.InsertAsync(value);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<List<T>> GetAllAsync()
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.Table<T>().ToListAsync();
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<T?> GetAsync(Guid id)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try

      {
        return await asyncConnection.GetAsync<T>(id);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }

    public async Task<int> UpdateAsync(T value)
    {
      var asyncConnection = new SQLiteAsyncConnection(_connectionString);
      try
      {
        return await asyncConnection.UpdateAsync(value);
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
        return await asyncConnection.DeleteAsync<T>(id);
      }
      finally
      {
        await asyncConnection.CloseAsync();
      }
    }
  }
}