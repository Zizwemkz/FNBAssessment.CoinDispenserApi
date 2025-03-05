using FNBAssessment.CoinDispenserApi.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FNBAssessment.CoinDispenserApi.T1.Test.Setup
{
  public abstract class ServiceBase
  {
    private DbContextOptions<CoinDispenserContext> _options;
    protected CoinDispenserContext Database;

    [SetUp]
    public void Setup()
    {
      var serviceProvider = new ServiceCollection()
          .AddEntityFrameworkInMemoryDatabase()
          .BuildServiceProvider();

      _options = new DbContextOptionsBuilder<CoinDispenserContext>()
          .UseInMemoryDatabase(Guid.NewGuid().ToString())
          .UseInternalServiceProvider(serviceProvider)
          .Options;

      Database = new CoinDispenserContext(_options);
      Database.Database.EnsureCreated();
      //SetupData();
    }

    [TearDown]
    public void TearDown()
    {
      Database.Database.EnsureDeleted();
      Database.Dispose();
    }
    //public abstract void SetupData();
  }
}
