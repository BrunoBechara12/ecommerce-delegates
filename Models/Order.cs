namespace OrderEvent.Models;

public class Order
{
    public int Id { get; set; }
    public List<ItemOrder> Product { get; set; }
    public string Client { get; set; }
    public string OrderNumber { get; set; }
    public decimal TotalValue { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<ItemOrder> ItemOrders { get; set; } = new();
    public Invoice Invoice { get; set; }
}
