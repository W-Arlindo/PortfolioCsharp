using System;
using System.Dynamic;
using Pedidos.Services;
using Pedidos.UI;

namespace Pedidos.Models;

class Cliente : IFalha
{
    //Dados cliente
    public int Id{get; private set;}
    public string? Nome{get; private set;}
    public string Email{get; private set;}
    public string mensfalha(string motivo){
        return$"Falha ao criar cliente\n{motivo}";
    }

    //Atribuindo dados do cliente
    public Cliente(int id, string nome,string email)
    {
        if (VerificarId(id))
        {
            Id=id;
        }
        else
        {
            throw new ArgumentException(mensfalha("Id invalido"));
        }
        if(verificarnome(nome)){
            Nome=nome;
        }
        else
        {
           throw new ArgumentException(mensfalha("Nome invalido"));
        }
        if(verificaremail(email)){
            Email=email;
        }
        else
        {
            throw new ArgumentException(mensfalha("Email invalido"));
        }
    }
    bool VerificarId(int i)
    {
        if (i <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //verificando nome do cliente
    bool verificarnome(string n)
    {
        if(n == null || string.IsNullOrWhiteSpace(n))
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
    //verificando email do cliente
    bool verificaremail(string e)
    {
        if(e == null || string.IsNullOrWhiteSpace(e))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
class Produto : IFalha
{
    //Dados do produto
    public int Id{get; private set;}
    public string Nome{get; private set;}
    public decimal Preco{get; private set;}
    public string mensfalha(string motivo)
    {
        return$"Falha ao cria produto\n{motivo}";
    }

    //atribuindo dados ao produto
    public Produto(int id,string nome, decimal preco)
    {
        if (VerificarId(id))
        {
            Id= id;
        }
        else
        {
            throw new ArgumentException(mensfalha("Id invalido"));
        }
        if (verificarnome(nome))
        {
            Nome=nome;
        }
        else
        {
            throw new ArgumentException(mensfalha("Nome invalido!"));
        }
        if (verificarpreco(preco))
        {
            Preco=preco;
        }
        else
        {
            throw new ArgumentException(mensfalha("Preco invalido"));
        }
    }
    
    bool VerificarId(int i)
    {
        if (i <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    //verificar nome do produto
    bool verificarnome(string n)
    {
        if(string.IsNullOrWhiteSpace(n))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //verificar preco do produto
    bool verificarpreco(decimal v)
    {
        if(v<=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
class Pedido:IFalha
{
    public int Numero{get; private set;}//identificar do pedido
    public Cliente cliente{get; private set;}
    public Produto produto{get; private set;}
    public int Quantidade{get; private set;}//do produto
    public decimal Vtotal{get;private set;}
    public bool CompraRealizada{get; private set;}
    public string mensfalha(string motivo)
    {
        return$"Falha ao criar pedido\n{motivo}";
    }
    
    public Pedido(Cliente c, Produto p, int q,int n)
    {
        if (verificarn(n))
        {
            Numero=n;
        }
        else
        {
          throw new ArgumentException( mensfalha("Numero invalido"));
        }
       
        if (verificarq(q))
        {
            Quantidade=q;
        }
        else
        {
            throw new ArgumentException(mensfalha("Quantidade invalida"));
        }
        
        cliente=c;
        produto=p;
        CompraRealizada=false;
        
        Vtotal =CalcularValores(produto.Preco,Quantidade);
    }
    public void Comprado()
    {
        CompraRealizada = true;
    }
    bool verificarn(int n)
    {
        if (n <=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    bool verificarq(int q)
    {
        if (q <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //somando valor total dos pedidos
    decimal CalcularValores(decimal v, int q)
    {
        return v*q;
    }
}