namespace OrderEvent.Dto;

public class CreateOrderDto
{
    public string Product { get; set; }
    public string Client { get; set; }
    public string Order { get; set; }
    public int Quantity { get; set; }
    public decimal TotalValue { get; set; }
}