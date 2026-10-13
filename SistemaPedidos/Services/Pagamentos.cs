using System;
using Pedidos.Models;

namespace Pedidos.Services;

class Pix : IPagamento
{
    public void Pagar(decimal valor)
    {
        Console.Clear();
        Console.WriteLine($"Pagamento realizado com Pix no total de R${valor}");
    }
}
class Cartao : IPagamento
{
    public void Pagar(decimal valor)
    {
        Console.Clear();
        Console.WriteLine($"Pagamento realizado com Cartao no total de R${valor}");
        
    }
}