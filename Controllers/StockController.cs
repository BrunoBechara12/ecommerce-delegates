using EcommerceDelegates.Dtos.Order;
using EcommerceDelegates.Models;
using EcommerceEvents.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderEvent.Models;
using OrderEvent.Services;

namespace EcommerceDelegates.Controllers;
[Route("api/stocks")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockService _stockService;
    public StockController(StockService stockService)
    {
        _stockService = stockService;
    }

    [HttpPut("Add")]
    public async Task<ActionResult<int>> AddStock(int productId, int quantity)
    {
        var stock = await _stockService.AddStock(productId, quantity);

        return Ok(stock);

    }

    [HttpPut("Remove")]
    public async Task<ActionResult<int>> RemoveStock(int productId, int quantity)
    {
        var stock = await _stockService.RemoveStock(productId, quantity);

        return Ok(stock);
    }
}
