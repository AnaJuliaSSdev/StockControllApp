using Models.DTO.BatchDto;
using Models.Models;
using Moq;
using StockApp2._0.Exceptions;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services;

namespace UnitTests.BatchServices;

public class EntryBatchProcessingStrategyTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly EntryBatchProcessingStrategy _strategy;

    public EntryBatchProcessingStrategyTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _strategy = new EntryBatchProcessingStrategy(_productRepositoryMock.Object);
    }

    [Fact]
    public async Task ProcessBatchAsync_ShouldThrowException_WhenProductIsPerishableAndExpiryDateIsMissing()
    {
        // Arrange
        var createBatchDto = new CreateBatchDto
        {
            ProductId = 1,
            ExpiryDate = null
        };
        _productRepositoryMock.Setup(r => r.GetProductByIdAsync(createBatchDto.ProductId))
            .ReturnsAsync(new Product { Perishable = true });

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidBatchException>(() => _strategy.ProcessBatchAsync(createBatchDto));
        Assert.Equal("Perishable products must have an expiry date.", exception.Message);
    }

    [Fact]
    public async Task ProcessBatchAsync_ShouldThrowException_WhenExpiryDateIsExpired()
    {
        // Arrange
        var createBatchDto = new CreateBatchDto
        {
            ProductId = 1,
            ExpiryDate = DateTime.UtcNow.AddDays(-1)
        };
        _productRepositoryMock.Setup(r => r.GetProductByIdAsync(createBatchDto.ProductId))
            .ReturnsAsync(new Product { Perishable = true });

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidBatchException>(() => _strategy.ProcessBatchAsync(createBatchDto));
        Assert.Equal("It is not possible to add a batch with an expired expiration date.", exception.Message);
    }
}
