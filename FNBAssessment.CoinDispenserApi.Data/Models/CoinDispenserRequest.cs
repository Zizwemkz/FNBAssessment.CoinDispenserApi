using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.Data.Models
{
  public class CoinDispenserRequest
  {
    [Required]
    public int[] Denominations { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Amount { get; init; }
  }
}
