using FNBAssessment.CoinDispenserApi.Common.Interface;
using FNBAssessment.CoinDispenserApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FNBAssessment.CoinDispenserApi.Controllers
{
  public class CoinDispenserController : Controller
  {
    private readonly ICoinDispenserService _coinDispenserService;

    public CoinDispenserController(ICoinDispenserService coinDispenserService)
    {
      _coinDispenserService = coinDispenserService;
    }

    [HttpPost("calculateMinimumCoins")]
    public async Task<IActionResult> CalculateMinimumCoins([FromBody] CoinDispenserRequest request)
    {
      try
      {
        var result = await _coinDispenserService.CalculateMinimumCoins(request.Denominations, request.Amount);
        return Ok(result);
      }
      catch (ArgumentException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
