using OrderEvent.Models;

namespace OrderEvent.Services;

public class StockService
{
    private readonly Dictionary<string, int> stock = new() 
    {
        {"Notebook", 10 },
        {"Mousepad", 5 },
        {"Teclado", 3 }
    };

    public void StockUpdate(Order order)
    {
        if (stock.ContainsKey(order.Product))
        {
            stock[order.Product] -= order.Quantity;
            Console.WriteLine($"📦 ESTOQUE atualizado para: {order.Product}");
            Console.WriteLine($"   Quantidade restante: {stock[order.Product]} unidades\n");
        }
    }

    public void StockValidation(Order order)
    {
        if(stock.ContainsKey(order.Product) && stock[order.Product] < order.Quantity)
        {
            throw new InvalidOperationException($"Estoque insuficiente para {order.Product}");
        }
    }
}
