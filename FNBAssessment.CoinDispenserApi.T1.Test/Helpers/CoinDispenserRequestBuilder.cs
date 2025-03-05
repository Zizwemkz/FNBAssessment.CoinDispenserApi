using Bogus;
using FNBAssessment.CoinDispenserApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.T1.Test.Helpers
{
  public class CoinDispenserRequestBuilder
  {
    private int[] _denominations;
    private int _amount;
    private Faker _faker = new Faker();

    public CoinDispenserRequestBuilder()
    {
      _denominations = new[] { 1, 2, 5, 10 };
      _amount = _faker.Random.Int(1, 100);
    }

    public CoinDispenserRequestBuilder WithInvalidDenominations()
    {
      _denominations = Array.Empty<int>();
      return this;
    }

    public CoinDispenserRequestBuilder WithNegativeAmount()
    {
      _amount = _faker.Random.Int(-100, -1);
      return this;
    }

    public CoinDispenserRequestBuilder WithZeroAmount()
    {
      _amount = 0;
      return this;
    }

    public CoinDispenserRequest Build()
    {
      return new CoinDispenserRequest
      {
        Denominations = _denominations,
        Amount = _amount
      };
    }
  }
}
