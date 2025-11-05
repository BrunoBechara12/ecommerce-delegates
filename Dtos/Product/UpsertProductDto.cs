using OrderEvent.Models;

namespace EcommerceEvents.Dtos.Product;

public class UpsertProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public int CategoryId { get; set; }
}
