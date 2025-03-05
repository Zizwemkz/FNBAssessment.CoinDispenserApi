using FNBAssessment.CoinDispenserApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.Data.DataAccess
{
  public class CoinDispenserContext : DbContext
  {
    public CoinDispenserContext(DbContextOptions<CoinDispenserContext> options) : base(options)
    {
    }

    public DbSet<CoinDispenser> CoinDispensers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Configure the Denominations and MinimumCoins properties as arrays
      modelBuilder.Entity<CoinDispenser>()
          .Property(e => e.Denominations)
          .HasConversion(
              v => string.Join(',', v),
              v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

      modelBuilder.Entity<CoinDispenser>()
          .Property(e => e.MinimumCoins)
          .HasConversion(
              v => string.Join(',', v),
              v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
    }
  }
}
