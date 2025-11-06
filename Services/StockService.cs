using EcommerceDelegates.Models;
using Microsoft.EntityFrameworkCore;
using OrderEvent.Data;

namespace OrderEvent.Services;

public class StockService
{
    public readonly AppDbContext _context;

    public StockService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddStock(int productId, int quantity)
    {
        var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == productId);

        if (product == null)
            throw new Exception("Produto não encontrado");

        var productStock = await _context.Stocks.FirstOrDefaultAsync(a => a.ProductId == productId);

        if (productStock == null)
        {
            productStock = new Stock()
            {
                ProductId = productId,
                Quantity = quantity,
                CreatedAt = DateTime.Now
            };
        }
        else
        {
            productStock.Quantity += quantity;
            productStock.UpdatedAt = DateTime.Now;
        }

        _context.Stocks.Update(productStock);

        await _context.SaveChangesAsync();

        return productStock.Quantity;
    }

    public async Task<int> RemoveStock(int productId, int quantity)
    {
        var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == productId);

        if (product == null)
            throw new Exception("Produto não encontrado");

        var productStock = await _context.Stocks.FirstOrDefaultAsync(a => a.ProductId == productId);

        if (productStock == null)
            throw new Exception("Não há estoque para este produto");

        if(productStock.Quantity < quantity)
        {
            productStock.Quantity = 0;
        }
        else
        {
            productStock.Quantity -= quantity;
        }
         
        productStock.UpdatedAt = DateTime.Now;

        _context.Stocks.Update(productStock);

         await _context.SaveChangesAsync();

        return productStock.Quantity;
    }

    public async Task<bool> StockValidation(int productId, int quantity)
    {
        var quantityStock = await _context.Stocks.FirstOrDefaultAsync(a => a.ProductId == productId);

        if(quantityStock == null)
            throw new Exception("Não há estoque para este produto");

        if (quantityStock!.Quantity < quantity)
        {
            return false;
        }

        return true;
    }
}
