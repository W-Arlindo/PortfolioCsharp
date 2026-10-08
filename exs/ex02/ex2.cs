using System;

namespace ex2;

class ContaBanking
{
    public string Titular{get; set;}
    public decimal Saldo{get; set;}

    public ContaBanking(string n, decimal s)
    {
        Titular=n;
        Saldo=s;
    }
}
class Sistem
{
    ContaBanking conta = new ContaBanking("Wenderson", 33);
    public void Depositar(decimal dinheiro)
    {
        conta.Saldo+=dinheiro;
    }
    public void Sacar(decimal dinheiro)
    {
        conta.Saldo-=dinheiro;
    }
    public void Consultar()
    {
        Console.WriteLine($"Titular: {conta.Titular}\nSaldo: {conta.Saldo}");

    }
}
class Program
{
    static void Main()
    {
        Sistem gerenciarconta = new Sistem();

        gerenciarconta.Depositar(20);
        gerenciarconta.Consultar();

        gerenciarconta.Sacar(15);
        gerenciarconta.Consultar();

    }
}