using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.Common.Interface
{
  public interface ICoinDispenserService
  {
    Task<int[]> CalculateMinimumCoins(int[] denominations, int amount);
  }
}
