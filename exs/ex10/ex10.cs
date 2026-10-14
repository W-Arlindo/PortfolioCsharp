using System;

namespace ex10;

interface NaoEncontrado
{
    void naoencontrado();
}

class Pedido : NaoEncontrado
{
    enum StatusPedido{Pendente = 1, Pago = 2, Enviado =3, Cancelado=4}

    public int Numero{get; private set;}
    public StatusPedido Status{get; private set;}

    public void naoencontrado()
    {
        Console.WriteLine("Pedido nao encontrado");
    }

    //Criando pedido
    public Pedido(int n)
    {
        verificarnumero(n);
        Status=StatusPedido.Pendente;
    }
    //verificando numero d pedido
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

    //altera status para pago
    public void Pagar(int n)
    {
        if (n == Numero)
        {
            Status=StatusPedido.Pago;
        }
        else
        {
            naoencontrado();
        }
    }

    //altera status para enviar
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

    //altera status para cancelado
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
class sistem
{
    //Exibir status
    public void ExibirStatus()
    {
        Console.WriteLine($"Pedido Numero: {p.Numero}");
        Console.WriteLine($"Situacao: {p.Status}");
    }

    //Criar pedido
    public void CriarPedido(int n)
    {
        Pedido p = new(n);
    }
    
}