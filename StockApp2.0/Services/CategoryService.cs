using Models.DTO.CategoryDto;
using Models.Models;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ListCategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        Category category = Mapper.Mapper.Map<Category>(createCategoryDto);
        await _categoryRepository.CreateCategoryAsync(category);
        return Mapper.Mapper.Map<ListCategoryDto>(category);
    }

    public async Task<IEnumerable<ListCategoryDto>> GetAllCategoriesAsync(int skip, int take)
    {
        IEnumerable<Category> categories = await _categoryRepository.GetAllCategoriesAsync(skip, take);
        List<ListCategoryDto> categoriesDto = [];
        categoriesDto.AddRange(from Category category in categories
                               select Mapper.Mapper.Map<ListCategoryDto>(category));
        return categoriesDto;
    }
}
