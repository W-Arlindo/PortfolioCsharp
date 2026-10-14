using System;

namespace ex10;


class Pedido
{
    enum StatusPedido{Pendente, Pago, Enviado, Cancelado}

    public int Numero{get; private set;}
    public StatusPedido Status{get; private set;}

    public Pedido(int n)
    {
        verificarnumero(n);
        Status=StatusPedido.Pendente;
    }
    bool verificarnumero(int n)
    {
        if (n <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Pagar(int n)
    {
        if (n == Numero)
        {
            Status=StatusPedido.Pago;
            Console.WriteLine("Pedido pago com sucesso");
        }
        else
        {
            Console.WriteLine("Pedido nao econtrado");
        }
    }
    public void Enviar(int n)
    {
        if (n == Numero)
        {
            Status=StatusPedido.Enviado;
        }
        else
        {
            Console.WriteLine("Pedido nao encontrado");
        }
    }
}