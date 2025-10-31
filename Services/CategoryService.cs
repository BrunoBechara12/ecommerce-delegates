using Microsoft.EntityFrameworkCore;
using OrderEvent.Data;
using OrderEvent.Dto;
using OrderEvent.Dtos.Category;
using OrderEvent.Models;

namespace OrderEvent.Services;

public class CategoryService
{
    public readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Category> createCategory (UpsertCategoryDto category)
    {
        var createdCategory = new Category()
        {
            Name = category.Name,
            Description = category.Description,
            Active = category.Active,
            CreatedAt = DateTime.Now
        };

        _context.Categories.AddAsync(createdCategory);
        await _context.SaveChangesAsync();

        return createdCategory;
    }
}
