using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderEvent.Dto;
using OrderEvent.Services;

namespace OrderEvent.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("CreateOrder")]
    public void CreateOrder([FromBody] CreateOrderDto order)
    {
       var createdOrder = _orderService.CreateOrder(order);

        Console.WriteLine($"Pedido {createdOrder.Id} finalizado!");

    }
}
