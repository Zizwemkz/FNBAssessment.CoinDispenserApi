using Bogus;
using FNBAssessment.CoinDispenserApi.Repository;
using FNBAssessment.CoinDispenserApi.T1.Test.Helpers;
using FNBAssessment.CoinDispenserApi.T1.Test.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.T1.Test.Tests.Repository
{
  [TestFixture]
  public class CoinDispenserRepositoryTests : ServiceBase
  {
    private CoinDispenserRepository _repository;
    private Faker _faker;

    [SetUp]
    public void SetUpRepository()
    {
      _repository = new CoinDispenserRepository(Database);
      _faker = new Faker();
    }

    [Test]
    public async Task Add_ValidCoinDispenser_AddsToDatabase()
    {
      // Arrange
      var coinDispenser = new CoinDispenserBuilder().Build();

      // Act
      await _repository.Add(coinDispenser);
      var result = await Database.CoinDispensers.FindAsync(coinDispenser.Id);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(coinDispenser.Amount, Is.EqualTo(result.Amount));
      Assert.That(coinDispenser.Denominations, Is.EqualTo(result.Denominations));
      Assert.That(coinDispenser.MinimumCoins, Is.EqualTo(result.MinimumCoins));
    }

    [Test]
    public void Add_NullCoinDispenser_ThrowsArgumentNullException()
    {
      // Act & Assert
      Assert.ThrowsAsync<ArgumentNullException>(() => _repository.Add(null));
    }

    [Test]
    public async Task Delete_ExistingCoinDispenser_RemovesFromDatabase()
    {
      // Arrange
      var coinDispenser = new CoinDispenserBuilder().Build();
      await Database.CoinDispensers.AddAsync(coinDispenser);
      await Database.SaveChangesAsync();

      // Act
      await _repository.Delete(coinDispenser.Id);
      var result = await Database.CoinDispensers.FindAsync(coinDispenser.Id);

      // Assert
      Assert.IsNull(result);
    }

    [Test]
    public async Task Delete_NonExistingCoinDispenser_DoesNothing()
    {
      // Arrange
      var nonExistingId = _faker.Random.Int(1000, 2000);

      // Act
      await _repository.Delete(nonExistingId);

      // Assert
      // No exception should be thrown and nothing should be deleted
      Assert.Pass();
    }
  }
}
