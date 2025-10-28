namespace OrderEvent.Models;

public class ItemOrder
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }

}
