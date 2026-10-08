using System;

namespace ex2;

class ContaBanking
{
    public string Titular{get;private set;}
    public decimal Saldo{get;private set;}

    public ContaBanking(string n)
    {
        Titular=n;
        Saldo=0;
    }
    public void Sacar(decimal valor)
    {
        if (valor > 0 && valor <= Saldo)
        {
            Saldo-=valor;
        }
    }
    public void Depositar(decimal valor)
    {
        if(valor > 0)
        {
            Saldo+=valor;
        }
    }
}
class Sistem
{
    ContaBanking conta = new ContaBanking("Wenderson");
    public void Depositar()
    {
        Console.Write("Depositar quanto: ");
        conta.Depositar(decimal.Parse(Console.ReadLine()));
    }
    public void Sacar()
    {
        Console.Write("Sacar quanto: ");
        conta.Sacar(decimal.Parse(Console.ReadLine()));
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

        gerenciarconta.Depositar();
        gerenciarconta.Consultar();

        gerenciarconta.Sacar();
        gerenciarconta.Consultar();

    }
}