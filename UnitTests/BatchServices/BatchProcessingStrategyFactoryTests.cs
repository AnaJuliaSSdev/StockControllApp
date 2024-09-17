using Models.Models;
using Moq;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services;

namespace UnitTests.BatchServices;

public class BatchProcessingStrategyFactoryTests
{
    [Fact]
    public void GetStrategy_ShouldReturnCorrectStrategy_ForEntryBatch()
    {
        // Arrange
        var serviceProviderMock = new Mock<IServiceProvider>();
        var entryStrategyMock = new Mock<EntryBatchProcessingStrategy>(Mock.Of<IProductRepository>());

        serviceProviderMock.Setup(sp => sp.GetService(typeof(EntryBatchProcessingStrategy)))
            .Returns(entryStrategyMock.Object);

        var factory = new BatchProcessingStrategyFactory(serviceProviderMock.Object);

        // Act
        var strategy = factory.GetStrategy(ETypeBatch.Entry);

        // Assert
        Assert.IsAssignableFrom<EntryBatchProcessingStrategy>(strategy);
    }

    [Fact]
    public void GetStrategy_ShouldReturnCorrectStrategy_ForExitBatch()
    {
        // Arrange
        var serviceProviderMock = new Mock<IServiceProvider>();
        var exitStrategyMock = new Mock<ExitBatchProcessingStrategy>(
            Mock.Of<IInventoryRepository>(),
            Mock.Of<IBatchRepository>());

        serviceProviderMock.Setup(sp => sp.GetService(typeof(ExitBatchProcessingStrategy)))
            .Returns(exitStrategyMock.Object);

        var factory = new BatchProcessingStrategyFactory(serviceProviderMock.Object);

        // Act
        var strategy = factory.GetStrategy(ETypeBatch.Exit);

        // Assert
        Assert.IsAssignableFrom<ExitBatchProcessingStrategy>(strategy);
    }
}
