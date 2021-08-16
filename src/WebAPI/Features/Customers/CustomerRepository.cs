using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Customers
{
  public class CustomerRepository : BaseRepository<Customer>
  {
    public CustomerRepository(string connectionString) : base(connectionString)
    {
    }
  }
}