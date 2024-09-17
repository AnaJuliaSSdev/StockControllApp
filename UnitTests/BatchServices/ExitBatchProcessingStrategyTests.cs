using Models.DTO.BatchDto;
using Moq;
using StockApp2._0.Exceptions;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services;

namespace UnitTests.BatchServices;

public class ExitBatchProcessingStrategyTests
{
    private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
    private readonly Mock<IBatchRepository> _batchRepositoryMock;
    private readonly ExitBatchProcessingStrategy _strategy;

    public ExitBatchProcessingStrategyTests()
    {
        _inventoryRepositoryMock = new Mock<IInventoryRepository>();
        _batchRepositoryMock = new Mock<IBatchRepository>();
        _strategy = new ExitBatchProcessingStrategy(_inventoryRepositoryMock.Object, _batchRepositoryMock.Object);
    }

    [Fact]
    public async Task ProcessBatchAsync_ShouldThrowException_WhenQuantityIsInsufficient()
    {
        // Arrange
        var createBatchDto = new CreateBatchDto
        {
            ProductId = 1,
            InventoryId = 1,
            Quantity = 100
        };
        _inventoryRepositoryMock.Setup(r => r.GetTotalAvailableQuantityByInventoryIdAndProductIdAsync(createBatchDto.ProductId, createBatchDto.InventoryId))
            .ReturnsAsync(50);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InsufficientProductQuantityException>(() => _strategy.ProcessBatchAsync(createBatchDto));
    }
}
