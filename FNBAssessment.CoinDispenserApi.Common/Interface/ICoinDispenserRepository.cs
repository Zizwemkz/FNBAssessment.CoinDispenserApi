using FNBAssessment.CoinDispenserApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.Common.Interface
{
  public interface ICoinDispenserRepository
  {
    Task Add(CoinDispenser coinDispenser);
    Task Delete(int id);
  }
}
