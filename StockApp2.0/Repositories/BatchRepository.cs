using Microsoft.EntityFrameworkCore;
using Models.Models;
using StockApp2._0.Context;
using StockApp2._0.Repositories.Interfaces;

namespace StockApp2._0.Repositories;

public class BatchRepository : IBatchRepository
{
    private StockAppContext _context;

    public BatchRepository(StockAppContext context)
    {
        _context = context;
    }

    public async Task<Batch> CreateBatchAsync(Batch batch)
    {
        _context.Batches.Add(batch);
        await _context.SaveChangesAsync();
        return batch;
    }

    public async Task<IEnumerable<Batch>> GetAllAvaliableBatchesByInventoryIdAndProductIdAsync(int productId, int inventoryId)
    {
        var currentDate = DateTime.Now;
        return await _context.Batches
        .Where(b => b.ProductId == productId && b.InventoryId == inventoryId)
        .Where(b => b.Quantity > 0 && (b.ExpiryDate != null && b.ExpiryDate >= currentDate) && b.TypeBatch == ETypeBatch.Entry)
        .OrderBy(b => b.ExpiryDate)
        .ThenBy(b => b.Quantity)
        .ToListAsync();
    }

    public async Task<IEnumerable<Batch>> GetAllBatchesAsync(int skip, int take)
    {
        return await _context.Batches
         .OrderBy(b => b.ExpiryDate)
         .ThenBy(b => b.Quantity)
         .Skip(skip)
         .Take(take)
         .ToListAsync();
    }

    public async Task UpdateBatchAsync(Batch batch)
    {
        _context.Batches.Update(batch);
        await _context.SaveChangesAsync();
    }
}
