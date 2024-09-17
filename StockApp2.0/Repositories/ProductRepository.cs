using Microsoft.EntityFrameworkCore;
using Models.Models;
using StockApp2._0.Context;
using StockApp2._0.Repositories.Interfaces;

namespace StockApp2._0.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StockAppContext _context;

    public ProductRepository(StockAppContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == product.Id);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(int skip, int take)
    {
        return await _context.Products.AsQueryable()
             .OrderBy(p => p.Id)
             .Skip(skip)
             .Take(take)
             .ToListAsync();

    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

}
