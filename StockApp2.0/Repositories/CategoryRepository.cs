using Microsoft.EntityFrameworkCore;
using Models.Models;
using StockApp2._0.Context;
using StockApp2._0.Repositories.Interfaces;

namespace StockApp2._0.Repositories;

public class CategoryRepository : ICategoryRepository
{

    private StockAppContext _context;

    public CategoryRepository(StockAppContext context)
    {
        _context = context;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(int skip, int take)
    {
        return await _context.Categories.AsQueryable()
           .OrderBy(c => c.Id)
           .Skip(skip)
           .Take(take)
           .ToListAsync();
    }
}
