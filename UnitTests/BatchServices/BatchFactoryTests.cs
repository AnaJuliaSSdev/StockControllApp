using Models.DTO.BatchDto;
using Models.Models;
using StockApp2._0.Services;

namespace UnitTests.BatchServices;

public class BatchFactoryTests
{
    private readonly BatchFactory _factory;

    public BatchFactoryTests()
    {
        _factory = new BatchFactory();
    }

    [Fact]
    public void CreateBatch_ShouldSetPropertiesCorrectly_WhenEntryBatch()
    {
        // Arrange
        var createBatchDto = new CreateBatchDto
        {
            InventoryId = 1,
            ProductId = 2,
            Quantity = 100,
            TypeBatch = ETypeBatch.Entry,
            Price = 10.0,
            ExpiryDate = DateTime.UtcNow.AddDays(10)
        };

        // Act
        var batch = _factory.CreateBatch(createBatchDto);

        // Assert
        Assert.Equal(createBatchDto.InventoryId, batch.InventoryId);
        Assert.Equal(createBatchDto.ProductId, batch.ProductId);
        Assert.Equal(createBatchDto.Quantity, batch.Quantity);
        Assert.Equal(createBatchDto.TypeBatch, batch.TypeBatch);
        Assert.Equal(createBatchDto.Price, batch.Price);
        Assert.Equal(createBatchDto.ExpiryDate, batch.ExpiryDate);
    }

    [Fact]
    public void CreateBatch_ShouldSetPriceAndExpiryDateToNull_WhenExitBatch()
    {
        // Arrange
        var createBatchDto = new CreateBatchDto
        {
            InventoryId = 1,
            ProductId = 2,
            Quantity = 100,
            TypeBatch = ETypeBatch.Exit,
            Price = 10.0,
            ExpiryDate = DateTime.UtcNow.AddDays(10)
        };

        // Act
        var batch = _factory.CreateBatch(createBatchDto);

        // Assert
        Assert.Null(batch.Price);
        Assert.Null(batch.ExpiryDate);
    }
}