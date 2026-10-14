using System;

namespace ex10;

interface NaoEncontrado
{
    void naoencontrado();
}

class Pedido : NaoEncontrado
{
    enum StatusPedido{Pendente, Pago, Enviado, Cancelado}

    public int Numero{get; private set;}
    public StatusPedido Status{get; private set;}

    public void naoencontrado()
    {
        Console.WriteLine("Pedido nao encontrado");
    }

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
            naoencontrado();
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
            naoencontrado();
        }
    }
    public void Cancelar(int n)
    {
        if (n == Numero)
        {
            Status=StatusPedido.Cancelado;
        }
        else
        {
            naoencontrado();
        }
    }
}