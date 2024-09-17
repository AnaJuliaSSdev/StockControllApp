using Models.Models;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class BatchProcessingStrategyFactory : IBatchProcessingStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BatchProcessingStrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IBatchProcessingStrategy GetStrategy(ETypeBatch typeBatch)
    {
        return typeBatch switch
        {
            ETypeBatch.Entry => _serviceProvider.GetRequiredService<EntryBatchProcessingStrategy>(),
            ETypeBatch.Exit => _serviceProvider.GetRequiredService<ExitBatchProcessingStrategy>(),
            _ => throw new ArgumentException("Invalid batch type.")
        };
    }
}
