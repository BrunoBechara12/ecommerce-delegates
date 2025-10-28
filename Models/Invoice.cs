namespace OrderEvent.Models;

public class Invoice
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
    public string OrderNumber { get; set; }
    public string Client { get; set; }
    public decimal TotalValue { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime IssuedAt { get; set; }
}

