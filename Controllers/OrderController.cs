using EcommerceDelegates.Dtos.Order;
using Microsoft.AspNetCore.Mvc;
using OrderEvent.Models;
using OrderEvent.Services;

namespace OrderEvent.Controllers;
[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderDto order)
    {
        var orders = await _orderService.CreateOrder(order);

        return Ok(orders);
    }
}
