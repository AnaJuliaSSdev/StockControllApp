using Moq;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;
using Models.DTO.BatchDto;
using Models.Models;
using StockApp2._0.Services;

namespace UnitTests.BatchServices;

public class BatchServiceTests
{
    private readonly Mock<IBatchRepository> _batchRepositoryMock;
    private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
    private readonly Mock<IBatchFactory> _batchFactoryMock;
    private readonly Mock<IBatchProcessingStrategyFactory> _strategyFactoryMock;
    private readonly BatchService _batchService;

    public BatchServiceTests()
    {
        _batchRepositoryMock = new Mock<IBatchRepository>();
        _inventoryRepositoryMock = new Mock<IInventoryRepository>();
        _batchFactoryMock = new Mock<IBatchFactory>();
        _strategyFactoryMock = new Mock<IBatchProcessingStrategyFactory>();
        _batchService = new BatchService(_batchRepositoryMock.Object, _inventoryRepositoryMock.Object, _batchFactoryMock.Object, _strategyFactoryMock.Object);
    }

    [Fact]
    public async Task CreateBatchAsync_ShouldCreateBatch_WhenValidDto()
    {
        // Arrange
        var createBatchDto = new CreateBatchDto
        {
            InventoryId = 1,
            ProductId = 1,
            Quantity = 10,
            TypeBatch = ETypeBatch.Entry,
            Price = 100.0,
            ExpiryDate = DateTime.UtcNow.AddDays(10)
        };

        var batch = new Batch
        {
            InventoryId = createBatchDto.InventoryId,
            ProductId = createBatchDto.ProductId,
            Quantity = createBatchDto.Quantity,
            TypeBatch = createBatchDto.TypeBatch,
            Price = createBatchDto.Price,
            ExpiryDate = createBatchDto.ExpiryDate
        };

        _batchFactoryMock.Setup(x => x.CreateBatch(createBatchDto)).Returns(batch);

        var entryStrategyMock = new Mock<IBatchProcessingStrategy>();
        _strategyFactoryMock.Setup(x => x.GetStrategy(createBatchDto.TypeBatch)).Returns(entryStrategyMock.Object);

        _batchRepositoryMock.Setup(x => x.CreateBatchAsync(batch)).Returns(Task.FromResult(batch));

        // Act
        var result = await _batchService.CreateBatchAsync(createBatchDto);

        // Assert
        Assert.NotNull(result);
        _batchFactoryMock.Verify(x => x.CreateBatch(createBatchDto), Times.Once);
        _strategyFactoryMock.Verify(x => x.GetStrategy(createBatchDto.TypeBatch), Times.Once);
        entryStrategyMock.Verify(x => x.ProcessBatchAsync(createBatchDto), Times.Once);
        _batchRepositoryMock.Verify(x => x.CreateBatchAsync(batch), Times.Once);
    }

    [Fact]
    public async Task GetAllBatchesAsync_ShouldReturnBatchDtos_WhenBatchesExist()
    {
        // Arrange
        var batches = new List<Batch> { new () };
        var batchDtos = new List<ListBatchDto> { new() };
        _batchRepositoryMock.Setup(r => r.GetAllBatchesAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(batches);

        // Act
        var result = await _batchService.GetAllBatchesAsync(0, 10);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }
}