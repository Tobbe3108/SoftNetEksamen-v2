using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features.Customer.Endpoints
{
  public partial class CustomerController
  {
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
      var result = await _repository.DeleteAsync(id);
      return result > 0 ? NoContent() : NotFound();
    }
  }
}