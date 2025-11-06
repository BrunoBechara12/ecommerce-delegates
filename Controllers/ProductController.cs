using EcommerceEvents.Dtos.Product;
using EcommerceEvents.Services;
using Microsoft.AspNetCore.Mvc;
using OrderEvent.Models;

namespace EcommerceEvents.Controllers;
[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<Product>> GetProducts()
    {
        var products = await _productService.GetProducts();

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] UpsertProductDto product)
    {
        var createdProduct = await _productService.CreateProduct(product);

        return Ok(createdProduct);
    }

    [HttpPut("{idProduct}")]
    public async Task<ActionResult<Product>> UpdateProduct([FromBody] UpsertProductDto product, int idProduct)
    {
        var updatedProduct = await _productService.UpdateProduct(product, idProduct);

        return Ok(updatedProduct);
    }

    [HttpDelete("{idProduct}")]
    public async Task<ActionResult<Product>> DeleteProduct(int idProduct)
    {
        var updatedProduct = await _productService.DeleteProduct(idProduct);

        return Ok(updatedProduct);
    }
}
