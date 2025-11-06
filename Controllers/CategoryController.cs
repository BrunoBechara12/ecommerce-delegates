using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<ActionResult<Category>> GetCategories()
    {
        var categories = await _categoryService.GetCategories();

        return Ok(categories);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory([FromBody] UpsertCategoryDto category)
    {
        var createdCategory = await _categoryService.CreateCategory(category);

        return Ok(createdCategory);
    }

    [HttpPut("{idCategory}")]
    public async Task<ActionResult<Category>> UpdateCategory([FromBody] UpsertCategoryDto category, int idCategory)
    {
        var updatedCategory = await _categoryService.UpdateCategory(category, idCategory);

        return Ok(updatedCategory);
    }

    [HttpDelete("{idCategory}")]
    public async Task<ActionResult<Category>> DeleteCategory(int idCategory)
    {
        var updatedCategory = await _categoryService.DeleteCategory(idCategory);

        return Ok(updatedCategory);
    }
}
