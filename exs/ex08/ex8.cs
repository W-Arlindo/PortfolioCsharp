using System;

namespace ex8;

class Cliente
{
    public string? Nome{get; private set;}
    public string? Email{get; private set;}

    public Cliente(string? nome,string? email)
    {
        Nome=nome;
        Email=email;
    }
}
class Pedido
{
    public int Numero{get;private set;}
    public decimal Valor{get; private set;}
    private Cliente cliente;

    public Pedido(int numero,decimal valor,Cliente cliente)
    {
        Numero=numero;
        Valor=valor;
        this.cliente=cliente;
    }

    public void ExibirResumo()
    {
        Console.WriteLine($"Nome: {cliente.Nome}\nEmail: {cliente.Email}\nPedido: {Numero}\nValor: {Valor}");
    }
}
class Program
{
    static void Main()
    {
        Cliente c1 = new("Smigle","pp@gmail.com");
        Pedido p1 = new(111,10,c1);
        Pedido p2 = new(112,20,c1);
        p1.ExibirResumo();
        p2.ExibirResumo();
    }
}