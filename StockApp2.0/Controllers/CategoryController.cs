using Microsoft.AspNetCore.Mvc;
using Models.DTO.CategoryDto;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDto createCategoryDto)
    {
        ListCategoryDto listCategoryDto = await _categoryService.CreateCategoryAsync(createCategoryDto);

        return Ok(listCategoryDto);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCategoriesAsync([FromQuery] int skip = 0, int take = 10)
    {
        IEnumerable<ListCategoryDto> categories = await _categoryService.GetAllCategoriesAsync(skip, take);
        return Ok(categories);
    }
}
