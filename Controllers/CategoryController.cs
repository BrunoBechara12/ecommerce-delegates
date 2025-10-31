using Microsoft.AspNetCore.Mvc;
using OrderEvent.Dto;
using OrderEvent.Dtos.Category;
using OrderEvent.Models;
using OrderEvent.Services;

namespace OrderEvent.Controllers;
[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateCategory([FromBody] UpsertCategoryDto category)
    {
        var createdCategory = await _categoryService.createCategory(category);

        return Ok(createdCategory);
    }

    [HttpPut("{idCategory}")]
    public async Task<ActionResult<Order>> updateCategory([FromBody] UpsertCategoryDto category, int idCategory)
    {
        var updatedCategory = await _categoryService.updateCategory(category, idCategory);

        return Ok(updatedCategory);
    }
}
