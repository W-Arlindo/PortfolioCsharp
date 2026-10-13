using System;

namespace Loja.Models;

class Produto
{
    public string Nome{get; private set;}
    public decimal Preco{get; private set;}
    public int Estoque{get; private set;}

    public Produto(string n,decimal p)
    {
        Nome = n;
        Preco = p;
        Estoque = 0;
    }
    public void AdicionarEstoque(int q)
    {
        if (q > 0)
        {
            Estoque+=q;
            Console.WriteLine("Adicionado com sucesso");
        }
    }
    public void RemoverEstoque(int q)
    {
        if(q<=Estoque && q > 0)
        {
            Estoque-=q;
            Console.WriteLine("removido com sucesso");
        }
    }
    /*public void AlterarEstoque(int q)
    {
        if(q <0 && -q < Estoque || q > 0)
        {
            if (Estoque + q >= 0)
            {
                Estoque+=q;
            }
        }
        
    }*/
    public void AlterarPreco(decimal v)
    {
        if(v > 0)
        {
            Preco=v;
            Console.WriteLine("Alterado com sucesso");
        }
    }
}