namespace OrderEvent.Models;

public class ResponseModel<T>
{
    public dynamic Dados { get; set; }
    public string Mensagem { get; set; }
    public bool Status { get; set; }
}

