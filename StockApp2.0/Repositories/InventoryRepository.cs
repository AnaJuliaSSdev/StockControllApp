using Microsoft.EntityFrameworkCore;
using Models.Models;
using StockApp2._0.Context;
using StockApp2._0.Repositories.Interfaces;

namespace StockApp2._0.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly StockAppContext _context;


    public InventoryRepository(StockAppContext context)
    {
        _context = context;
    }

    public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();
        return inventory;
    }

    public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync(int skip, int take)
    {
        return await _context.Inventories.AsQueryable()
             .Include(i => i.Batches)
             .OrderByDescending(i => i.Batches.Sum(b => b.Quantity))
             .Skip(skip)
             .Take(take)
             .ToListAsync();
    }

    public async Task<double> GetTotalAvailableQuantityByInventoryIdAndProductIdAsync(int productId, int inventoryId)
    {
        return await _context.Batches
         .Where(b => b.InventoryId == inventoryId && b.ProductId == productId)
         .SumAsync(b => b.TypeBatch == ETypeBatch.Exit ? -b.Quantity : b.Quantity);
    }
}
