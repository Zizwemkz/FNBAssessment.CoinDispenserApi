using Bogus;
using FNBAssessment.CoinDispenserApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.T1.Test.Helpers
{
  public class CoinDispenserBuilder
  {
    private Faker _faker = new Faker();
    private CoinDispenser _coinDispenser;

    public CoinDispenserBuilder()
    {
      _coinDispenser = new CoinDispenser
      {
        Id = _faker.Random.Int(1, 1000),
        Denominations = new[] { 1, 2, 5, 10 },
        Amount = _faker.Random.Int(1, 100),
        MinimumCoins = new[] { 0, 1, 1, 2 }
      };
    }

    public CoinDispenserBuilder WithId(int id)
    {
      _coinDispenser.Id = id;
      return this;
    }

    public CoinDispenserBuilder WithDenominations(int[] denominations)
    {
      _coinDispenser.Denominations = denominations;
      return this;
    }

    public CoinDispenserBuilder WithAmount(int amount)
    {
      _coinDispenser.Amount = amount;
      return this;
    }

    public CoinDispenserBuilder WithMinimumCoins(int[] minimumCoins)
    {
      _coinDispenser.MinimumCoins = minimumCoins;
      return this;
    }

    public CoinDispenser Build()
    {
      return _coinDispenser;
    }
  }
}
