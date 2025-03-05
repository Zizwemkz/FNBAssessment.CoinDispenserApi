using Bogus;
using FNBAssessment.CoinDispenserApi.Common.Interface;
using FNBAssessment.CoinDispenserApi.Data.Models;
using FNBAssessment.CoinDispenserApi.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.T1.Test.Tests.Service
{
  [TestFixture]
  public class CoinDispenserServiceTests
  {
    private Mock<ICoinDispenserRepository> _repositoryMock;
    private CoinDispenserService _service;
    private Faker _faker;

    [SetUp]
    public void SetUp()
    {
      _repositoryMock = new Mock<ICoinDispenserRepository>();
      _service = new CoinDispenserService(_repositoryMock.Object);
      _faker = new Faker();
    }

    [Test]
    public async Task GivenCalculateMinimumCoins_WhenValidInput_ShouldReturnsCorrectResult()
    {
      // Arrange
      var denominations = new[] { 1, 2, 5, 10 };
      var amount = 28;

      var expectedCoins = new[] { 2, 1, 1, 1 };

      // Act
      var result = await _service.CalculateMinimumCoins(denominations, amount);

      // Assert
      Assert.That(result, Is.EqualTo(expectedCoins));
      _repositoryMock.Verify(x => x.Add(It.IsAny<CoinDispenser>()), Times.Once);
    }

    [Test]
    public void GivenCalculateMinimumCoins_WhenNullDenominations_ShouldThrowsArgumentException()
    {
      // Arrange
      int[] denominations = null;
      var amount = _faker.Random.Int(1, 100);

      // Act & Assert
      var ex = Assert.ThrowsAsync<ArgumentException>(() => _service.CalculateMinimumCoins(denominations, amount));
      Assert.That(ex.Message, Is.EqualTo("Denominations cannot be null or empty. (Parameter 'denominations')"));
    }

    [Test]
    public void CalculateMinimumCoins_WhenEmptyDenominations_ShouldThrowsArgumentException()
    {
      // Arrange
      var denominations = Array.Empty<int>();
      var amount = _faker.Random.Int(1, 100);

      // Act & Assert
      var ex = Assert.ThrowsAsync<ArgumentException>(() => _service.CalculateMinimumCoins(denominations, amount));
      Assert.That(ex.Message, Is.EqualTo("Denominations cannot be null or empty. (Parameter 'denominations')"));
    }

    [Test]
    public void GivenCalculateMinimumCoins_WhenNegativeAmount_ShouldThrowsArgumentException()
    {
      // Arrange
      var denominations = new[] { 1, 2, 5, 10 };
      var amount = _faker.Random.Int(-100, -1);

      // Act & Assert
      var ex = Assert.ThrowsAsync<ArgumentException>(() => _service.CalculateMinimumCoins(denominations, amount));
      Assert.That(ex.Message, Is.EqualTo("Amount cannot be negative. (Parameter 'amount')"));
    }

    [Test]
    public async Task GivenCalculateMinimumCoins_WhenAmountZero_ShouldReturnsEmptyArray()
    {
      // Arrange
      var denominations = new[] { 1, 2, 5, 10 };
      var amount = 0;

      var expectedCoins = new[] { 0, 0, 0, 0 };

      // Act
      var result = await _service.CalculateMinimumCoins(denominations, amount);

      // Assert
      Assert.That(result, Is.EqualTo(expectedCoins));
      _repositoryMock.Verify(x => x.Add(It.IsAny<CoinDispenser>()), Times.Once);
    }

    [Test]
    public async Task GivenCalculateMinimumCoins_WhenLargeAmount_ShouldReturnsCorrectResult()
    {
      // Arrange
      var denominations = new[] { 1, 2, 5, 10, 25, 50, 100 };
      var amount = 1234;

      var expectedCoins = new[] { 2, 1, 1, 0, 1, 0, 12 };

      // Act
      var result = await _service.CalculateMinimumCoins(denominations, amount);

      // Assert
      Assert.That(result[6], Is.EqualTo(0));  // 0x1
      Assert.That(result[5], Is.EqualTo(2));  // 2x2
      Assert.That(result[4], Is.EqualTo(1));  // 1x5
      Assert.That(result[3], Is.EqualTo(0));  // 0x10
      Assert.That(result[2], Is.EqualTo(1));  // 1x25
      Assert.That(result[1], Is.EqualTo(0));  // 0x50
      Assert.That(result[0], Is.EqualTo(12)); // 12x100
      _repositoryMock.Verify(x => x.Add(It.IsAny<CoinDispenser>()), Times.Once);
    }
  }
}
