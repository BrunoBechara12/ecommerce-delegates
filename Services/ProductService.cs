using EcommerceDelegates.Models;
using EcommerceEvents.Dtos.Product;
using Microsoft.EntityFrameworkCore;
using OrderEvent.Data;
using OrderEvent.Models;

namespace EcommerceEvents.Services;

public class ProductService
{
    public readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();

        return products;
    }

    public async Task<Product> CreateProduct(UpsertProductDto product)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == product.CategoryId);

        if (category == null)
            throw new Exception("Categoria não encontrada");

        var createdProduct = new Product()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Active = product.Active,
            CategoryId = product.CategoryId,
            CreatedAt = DateTime.Now
        };

        await _context.Products.AddAsync(createdProduct);
        await _context.SaveChangesAsync();

        return createdProduct;
    }
    public async Task<Product> UpdateProduct(UpsertProductDto product, int idProduct)
    {
        var updateProduct = _context.Products.FirstOrDefault(a => a.Id == idProduct);

        if (updateProduct == null)
            throw new Exception("Produto não encontrado");

        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == product.CategoryId);

        if (category == null)
            throw new Exception("Categoria não encontrada");

        updateProduct.Name = product.Name;
        updateProduct.Description = product.Description;
        updateProduct.Price = product.Price;
        updateProduct.Active = product.Active;
        updateProduct.Category = category;
        updateProduct.UpdatedAt = DateTime.Now;

        _context.Update(updateProduct);

        await _context.SaveChangesAsync();

        return updateProduct;
    }

    public async Task<Product> DeleteProduct(int idProduct)
    {
        var deleteProduct = _context.Products.FirstOrDefault(a => a.Id == idProduct);

        if (deleteProduct == null)
            throw new Exception("Produto não encontrado");

        _context.Remove(deleteProduct);

        await _context.SaveChangesAsync();

        return deleteProduct;
    }
}
