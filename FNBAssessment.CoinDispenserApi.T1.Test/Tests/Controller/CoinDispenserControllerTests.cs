using Bogus;
using FNBAssessment.CoinDispenserApi.Common.Interface;
using FNBAssessment.CoinDispenserApi.Controllers;
using FNBAssessment.CoinDispenserApi.T1.Test.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNBAssessment.CoinDispenserApi.T1.Test.Tests.Controller
{
  [TestFixture]
  public class CoinDispenserControllerTests : IDisposable
  {
    private Mock<ICoinDispenserService> _coinDispenserServiceMock;
    private CoinDispenserController _controller;
    private Faker _faker;

    [SetUp]
    public void SetUp()
    {
      _coinDispenserServiceMock = new Mock<ICoinDispenserService>();
      _controller = new CoinDispenserController(_coinDispenserServiceMock.Object);
      _faker = new Faker();
    }

    [Test]
    public async Task CalculateMinimumCoins_ValidRequest_ReturnsOkResult()
    {
      // Arrange
      var request = new CoinDispenserRequestBuilder().Build();
      var expectedCoins = new[] { 2, 1, 0, 3 };

      _coinDispenserServiceMock
          .Setup(service => service.CalculateMinimumCoins(request.Denominations, request.Amount))
          .ReturnsAsync(expectedCoins);

      // Act
      var result = await _controller.CalculateMinimumCoins(request);

      // Assert
      var okResult = result as OkObjectResult;
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult.Value, Is.EqualTo(expectedCoins));
    }

    [Test]
    public async Task CalculateMinimumCoins_InvalidDenominations_ReturnsBadRequest()
    {
      // Arrange
      var request = new CoinDispenserRequestBuilder()
          .WithInvalidDenominations()
          .Build();

      _coinDispenserServiceMock
          .Setup(service => service.CalculateMinimumCoins(request.Denominations, request.Amount))
          .ThrowsAsync(new ArgumentException("Denominations cannot be null or empty."));

      // Act
      var result = await _controller.CalculateMinimumCoins(request);

      // Assert
      var badRequestResult = result as BadRequestObjectResult;
      Assert.That(badRequestResult, Is.Not.Null);
      Assert.That(badRequestResult.Value, Is.EqualTo("Denominations cannot be null or empty."));
    }

    [Test]
    public async Task CalculateMinimumCoins_NegativeAmount_ReturnsBadRequest()
    {
      // Arrange
      var request = new CoinDispenserRequestBuilder()
          .WithNegativeAmount()
          .Build();

      _coinDispenserServiceMock
          .Setup(service => service.CalculateMinimumCoins(request.Denominations, request.Amount))
          .ThrowsAsync(new ArgumentException("Amount cannot be negative."));

      // Act
      var result = await _controller.CalculateMinimumCoins(request);

      // Assert
      var badRequestResult = result as BadRequestObjectResult;
      Assert.That(badRequestResult, Is.Not.Null);
      Assert.That(badRequestResult.Value, Is.EqualTo("Amount cannot be negative."));
    }

    [Test]
    public async Task CalculateMinimumCoins_ZeroAmount_ReturnsOkResult()
    {
      // Arrange
      var request = new CoinDispenserRequestBuilder()
          .WithZeroAmount()
          .Build();

      var expectedCoins = new[] { 0, 0, 0, 0 };

      _coinDispenserServiceMock
          .Setup(service => service.CalculateMinimumCoins(request.Denominations, request.Amount))
          .ReturnsAsync(expectedCoins);

      // Act
      var result = await _controller.CalculateMinimumCoins(request);

      // Assert
      var okResult = result as OkObjectResult;
      Assert.That(okResult, Is.Not.Null);
      Assert.That(okResult.Value, Is.EqualTo(expectedCoins));
    }

    public void Dispose()
    {
      _controller?.Dispose();
    }
  }
}
