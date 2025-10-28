using OrderEvent.Models;

namespace OrderEvent.Services;

public class DeliveryService
{
    public void SendProduct(Order order)
    {
        Console.WriteLine($"🚚 Entrega agendada para: {DateTime.Now.AddDays(3)}");
    }
}
