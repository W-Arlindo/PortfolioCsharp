using System;

namespace ex9;

interface IPagamento
{
    void Pagar(decimal valor);
}
class PagamentoPix : IPagamento
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagamento com pix!\nValor: {valor}");

    }
}
class PagamentoCartao : IPagamento
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagamento com cartao!\nValor: {valor}");

    }
}
class PagamentoBoleto : IPagamento
{
    public void Pagar(decimal valor)
    {
        Console.WriteLine($"Pagamento com boleto\nValor: {valor}");
    }
}
class Pedido
{
    public decimal Valor{get; private set;}
    public int Numero{get; private set;}
    private IPagamento pagamento;
    public Pedido(decimal valor,int n, IPagamento pagamento)
    {
        Valor=valor;
        Numero=n;
        this.pagamento=pagamento;
    }
    public void AlterarPagamento(IPagamento alt)
    {
        pagamento=alt;
    }
    public void FinalizarPedido()
    {
        Console.WriteLine($"Novo Pedido\nNumero: {Numero}");
        pagamento.Pagar(Valor);
    }
}
class Program
{
    static void Main()
    {
        IPagamento Boleto = new PagamentoBoleto();
        Pedido p1 = new(7.5m,117,Boleto);
        Pedido p2 = new(3,118,new PagamentoPix());
        Pedido p3 = new(10,119,new PagamentoCartao());
        p2.AlterarPagamento(new PagamentoCartao());
        p1.FinalizarPedido();
        p2.FinalizarPedido();
        p3.FinalizarPedido();
    }
}