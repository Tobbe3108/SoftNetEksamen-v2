using WebAPI.Core.Interfaces;

namespace WebAPI.Features.Rentals
{
  public class RentalRepository : BaseRepository<Rental>
  {
    public RentalRepository(string connectionString) : base(connectionString)
    {
    }
  }
}