using FNBAssessment.CoinDispenserApi.Common.Interface;
using FNBAssessment.CoinDispenserApi.Data.Models;

namespace FNBAssessment.CoinDispenserApi.Service
{
  public class CoinDispenserService : ICoinDispenserService
  {
    private readonly ICoinDispenserRepository _repository;

    public CoinDispenserService(ICoinDispenserRepository repository)
    {
      _repository = repository;
    }

    public async Task<int[]> CalculateMinimumCoins(int[] denominations, int amount)
    {
      if (denominations == null || denominations.Length == 0)
        throw new ArgumentException("Denominations cannot be null or empty.", nameof(denominations));

      if (amount < 0)
        throw new ArgumentException("Amount cannot be negative.", nameof(amount));

      // Sort denominations in descending order
      Array.Sort(denominations, (a, b) => b.CompareTo(a));

      int[] minimumCoins = new int[denominations.Length];
      int remainingAmount = amount;

      for (int i = 0; i < denominations.Length; i++)
      {
        minimumCoins[i] = remainingAmount / denominations[i];
        remainingAmount %= denominations[i];
      }

      var coinDispenser = new CoinDispenser
      {
        Denominations = denominations,
        Amount = amount,
        MinimumCoins = minimumCoins
      };

      // Save the calculated result to the repository
      await _repository.Add(coinDispenser);

      return minimumCoins;
    }
  }
}
