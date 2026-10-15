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
        if(p.Status == Pedido.StatusPedido.Cancelado||p.Status== Pedido.StatusPedido.Enviado)
        {
            Console.WriteLine("Nao e possivel fazer alteracao");
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
        Console.WriteLine("===");
        Console.WriteLine($"Numero: {this.p.Numero}\nStatus: {this.p.Status}");
    }

    //pagar pedido
    public void Pagar()
    {
        if (p.Status == Pedido.StatusPedido.Pendente)
        {
            p.Pagar();
        }
    }

    //Enviar pedido
    public void Enviar()
    {
        if (p.Status == Pedido.StatusPedido.Pago)
        {
            p.Enviar();
        }
    }

    //cancelar pedido
    public void Cancelar()
    {
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