using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Features.Containers;

namespace WebAPI.Core.Interfaces
{
  public interface IContainerService
  {
    Task<bool> CreateTableAsync();
    Task<int> CreateAsync(Container container);
    Task<List<Container>> GetAllAsync();
    Task<Container?> GetAsync(Guid id);
    Task<int> UpdateAsync(Container container);
    Task<int> DeleteAsync(Guid id);
  }
}