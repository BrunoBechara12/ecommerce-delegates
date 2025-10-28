namespace OrderEvent.Models;

public class Order
{
    public int Id { get; set; }
    public string Product { get; set; }
    public string Client { get; set; }
    public string OrderNumber { get; set; }
    public int Quantity { get; set; }
    public decimal TotalValue { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<ItemOrder> ItemOrders { get; set; }
    public List<Product> Products { get; set; }
}
