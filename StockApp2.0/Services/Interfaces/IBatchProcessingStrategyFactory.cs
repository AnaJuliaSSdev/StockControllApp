using Models.Models;

namespace StockApp2._0.Services.Interfaces;

public interface IBatchProcessingStrategyFactory
{
    IBatchProcessingStrategy GetStrategy(ETypeBatch typeBatch);
}
