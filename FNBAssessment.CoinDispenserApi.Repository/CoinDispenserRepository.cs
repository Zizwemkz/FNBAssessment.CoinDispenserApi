using FNBAssessment.CoinDispenserApi.Common.Interface;
using FNBAssessment.CoinDispenserApi.Data.DataAccess;
using FNBAssessment.CoinDispenserApi.Data.Models;

namespace FNBAssessment.CoinDispenserApi.Repository
{
  public class CoinDispenserRepository : ICoinDispenserRepository
  {
    private readonly CoinDispenserContext _context;

    public CoinDispenserRepository(CoinDispenserContext context)
    {
      _context = context;
    }

    public async Task Add(CoinDispenser coinDispenser)
    {
      await _context.CoinDispensers.AddAsync(coinDispenser);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      var coinDispenser = await _context.CoinDispensers.FindAsync(id);
      if (coinDispenser != null)
      {
        _context.CoinDispensers.Remove(coinDispenser);
        await _context.SaveChangesAsync();
      }
    }
  }
}
