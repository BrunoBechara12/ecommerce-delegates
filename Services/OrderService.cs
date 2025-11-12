using EcommerceDelegates.Dtos.Order;
using Microsoft.EntityFrameworkCore;
using OrderEvent.Data;
using OrderEvent.Models;

namespace OrderEvent.Services;

public class OrderService
{
    public delegate void OrderEventHandler(Order order);

    public event OrderEventHandler? OnEventCreation;
    public event OrderEventHandler? OnEventValidation;

    public readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrder(CreateOrderDto order)
    {
        var createdOrder = new Order()
        {
            Client = order.Client,
            Product = new List<ItemOrder>(),
            OrderNumber = Guid.NewGuid(),
            CreatedAt = DateTime.Now
        };

        decimal calculatedTotal = 0;

        foreach (var item in order.Products)
        {
            var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == item.ProductId);

            if(product == null)
            {
                throw new Exception("Produto não encontrado!");
            }

            var productOrder = new ItemOrder
            {
                Quantity = item.Quantity,
                UnitValue = item.UnitValue,
                TotalValue = item.Quantity * item.UnitValue,
                ProductId = item.ProductId,
                Order = createdOrder
            };

            createdOrder.ItemOrders.Add(productOrder);
            calculatedTotal += productOrder.TotalValue;
        }

        createdOrder.TotalValue = calculatedTotal;

        await _context.Orders.AddAsync(createdOrder);

        await _context.SaveChangesAsync();

        OnEventCreation?.Invoke(createdOrder);

        return createdOrder;
    }

}
