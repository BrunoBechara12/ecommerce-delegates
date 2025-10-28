namespace OrderEvent.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int categoryId { get; set; }

    public Category Category { get; set; }
    public List<ItemOrder> ItemOrders { get; set; }
    public List<Order> orders { get; set; }

}
