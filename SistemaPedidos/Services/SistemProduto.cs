using System;
using Pedidos.Models;
using Pedidos.UI;

namespace Pedidos.Services;

class SistemProduto
{
    MProduto menup = new();

    List<Produto> produtos = new();

    //Criando produto
    public Produto CadastrarProduto()
    {
        Console.WriteLine("===== Criando Produto =====");
        
        int id = menup.ReceberId();
        string nome = menup.ReceberNome();
        decimal preco= menup.ReceberPreco();

        Produto _ = new Produto(id,nome, preco);

        adicionarlista(_);

        Console.Clear();
        return _;
    }

    //Adicionando a lista
    void adicionarlista(Produto _)
    {
        produtos.Add(_);
    }

    //Listando Produtos
    public void ListarProdutos()
    {
        Console.WriteLine("===== Produtos =====");
        foreach(Produto produto in produtos)
        {
            Console.WriteLine($"Id: {produto.Id}");
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Preco: {produto.Preco}");
            Console.WriteLine("= = = = = =");
        }
    }

    //passar metodo para class SistemaPedido
    //Verificando Produtos
    public Produto VerificarProduto(int id)
    {
        //Verificar existencia do produto
        Console.Write("");
        foreach (Produto produto in produtos)
        {
            if(id == produto.Id)
            {
                return produto;
            }
        }
        throw new InvalidOperationException("Produto nao encontrado");

    }
}