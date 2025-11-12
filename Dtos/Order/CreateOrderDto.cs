using OrderEvent.Models;

namespace EcommerceDelegates.Dtos.Order;

public class CreateOrderDto
{
    public List<ItemOrderDto> Products { get; set; }
    public string Client { get; set; }
}
