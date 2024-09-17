using Microsoft.AspNetCore.Mvc;
using Models.DTO.Product;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto productDto)
    {
        ListProductDto listProductDto = await  _productService.CreateProductAsync(productDto);

        return Ok(listProductDto);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProductsAsync([FromQuery] int skip = 0, int take = 10)
    {
        IEnumerable<ListProductDto> products = await _productService.GetAllProductsAsync(skip, take);
        return Ok(products);
    }
}   

