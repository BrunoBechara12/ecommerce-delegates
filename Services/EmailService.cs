using OrderEvent.Models;

namespace OrderEvent.Services;

public class EmailService
{
    public void SendEmail(Order order)
    {
        Console.WriteLine($"📧 Email enviado para cliente {order.Client}\n");
    }
}
