using OrderEvent.Models;

namespace EcommerceDelegates.Models;

public class Stock
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Product Product { get; set; }
}
