using System;

namespace ex10;

class Pedido
{
    public enum StatusPedido{Pendente = 1, Pago = 2, Enviado =3, Cancelado=4}

    public int Numero{get; private set;}
    public StatusPedido Status{get; private set;}


    //Criando pedido
    public Pedido(int n)
    {
        if (verificarnumero(n))
        {
            Numero=n;
            Status=StatusPedido.Pendente;
        }
        else
        {
            Console.WriteLine("Pedido ja existente");
        }
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
    public void Pagar()
    {
        Status=StatusPedido.Pago;
    }

    //altera status para enviar
    public void Enviar()
    {
        Status=StatusPedido.Enviado;
    }

    //altera status para cancelado
    public void Cancelar()
    {
        Status=StatusPedido.Cancelado;
    }
}

class sistem
{
    Pedido p;
    void verificar(Pedido p)
    {
        if(p.Status == Pedido.StatusPedido.Cancelado)
        {
            Console.WriteLine("Nao e possivel fazer alteracao, pedido ja foi cancelado");
            return;
        }
        else if(p.Status == Pedido.StatusPedido.Enviado)
        {
            Console.WriteLine("Nao e possivel fazer alteracao, pedido ja foi enviado");
            return;
        }
    }

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
        this.p=p;
        Console.WriteLine("=== Pedido criado");
        ExibirStatus();
    }

    //pagar pedido
    public void Pagar()
    {
        Console.WriteLine("=== Pagar");
        if (p.Status == Pedido.StatusPedido.Pendente)
        {
            p.Pagar();
            Console.WriteLine("Pago com sucesso");
        }
        else
        {
            Console.WriteLine("Pedido nao estar pendente");
        }
    }

    //Enviar pedido
    public void Enviar()
    {
        Console("=== Enviar");
        if (p.Status == Pedido.StatusPedido.Pago)
        {
            p.Enviar();
        }
    }

    //cancelar pedido
    public void Cancelar()
    {
        Console.WriteLine("=== Cancelar");
        if (p.Status == Pedido.StatusPedido.Pendente)
        {
            p.Cancelar();
        }
    }
}
class Program
{
    static void Main()
    {
        sistem s = new();

        s.CriarPedido(1);

    }
}