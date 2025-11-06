using Microsoft.EntityFrameworkCore;
using OrderEvent.Data;
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

    public async Task<List<Category>> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();

        return categories;
    }

    public async Task<Category> CreateCategory(UpsertCategoryDto category)
    {
        var createdCategory = new Category()
        {
            Name = category.Name,
            Description = category.Description,
            Active = category.Active,
            CreatedAt = DateTime.Now
        };

        await _context.Categories.AddAsync(createdCategory);
        await _context.SaveChangesAsync();

        return createdCategory;
    }

    public async Task<Category> UpdateCategory(UpsertCategoryDto category, int idCategory)
    {
        var updateCategory = _context.Categories.FirstOrDefault(a => a.Id == idCategory);

        if(updateCategory != null)
        {
            updateCategory.Name = category.Name;
            updateCategory.Description = category.Description;
            updateCategory.Active = category.Active;
            updateCategory.UpdatedAt = DateTime.Now;

            _context.Update(updateCategory);

            await _context.SaveChangesAsync();
        }

        return updateCategory;
    }

    public async Task<Category> DeleteCategory(int idCategory)
    {
        var deleteCategory = _context.Categories.FirstOrDefault(a => a.Id == idCategory);

        if (deleteCategory != null)
        {
            _context.Remove(deleteCategory);

            await _context.SaveChangesAsync();
        }

        return deleteCategory;
    }
}
