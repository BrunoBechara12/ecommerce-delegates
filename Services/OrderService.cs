using OrderEvent.Dto;
using OrderEvent.Models;

namespace OrderEvent.Services;

public class OrderService
{
    public delegate void OrderEventHandler(Order order);

    public event OrderEventHandler? OnEventCreation;
    public event OrderEventHandler? OnEventValidation;

    private List<Order> orderList = new();

    public Order CreateOrder(CreateOrderDto order)
    {
        int Id = orderList.LastOrDefault() != null ? orderList.LastOrDefault()!.Id + 1 : 1;

        Order createdOrder = new Order()
        {
            Id = Id,
            Client = order.Client,
            Product = order.Product,
            OrderNumber = order.Order,
            Quantity = order.Quantity,
            TotalValue = order.TotalValue,
            CreatedAt = DateTime.Now
        };

        OnEventValidation?.Invoke(createdOrder);

        OnEventCreation?.Invoke(createdOrder);

        return createdOrder;
    }

}
