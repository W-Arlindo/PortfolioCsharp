using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Loja.Models;
using Microsoft.VisualBasic;

namespace Loja.Services;

class Sistem
{
    List<Produto> produtos = new List<Produto>();

    private void AdicionarLIsta(Produto produto)
    {
        produtos.Add(produto);
    }

    public void CadastrarProdutos()
    {
        Console.WriteLine("\n\n\n=== Cadastrar Produto ===");
        string nome = Nome();
        decimal preco = Preco();
       
        Produto produto = new Produto(nome,preco);
        AdicionarLIsta(produto);
    }
    private string Nome()
    {
        string nome;
        Console.Write("Nome: ");nome=Console.ReadLine();
        return nome;
    }
     private decimal Preco()
    {
        decimal Preco;
        Console.Write("Preco: ");Preco=decimal.Parse(Console.ReadLine());
        return Preco;
    }

    public void AdicionarEstoque(string n)
    {
        int adicionarestoque;
        
        foreach (var p in produtos)
        {
            if(p.Nome.ToUpper() == n.ToUpper())
            {
                Console.Write("Adicionar quanto: ");
                if(int.TryParse(Console.ReadLine(),out adicionarestoque))
                {
                    p.AdicionarEstoque(adicionarestoque);
                }
            }
        }
        
    }
    public void RemoverEstoque(string n)
    {
        int removerestoque;
        
        foreach (var p in produtos)
        {
            if (p.Nome.ToLower() == n.ToLower())
            {
                Console.Write("Remover quanto: ");
               if(int.TryParse(Console.ReadLine(), out removerestoque))
                {
                    p.RemoverEstoque(removerestoque);
                }
            }
        }
    }
    public void AlterarPreco(string n)
    {
        decimal novopreco;
        
        foreach (var p in produtos)
        {
            if (p.Nome.ToLower() == n.ToLower())
            {
                Console.Write("Novo preco: ");
                if(decimal.TryParse(Console.ReadLine(),out novopreco))
                {
                    p.AlterarPreco(novopreco);
                }
            }
        }
    }
    /*public void CalcularValorTotalEmEstoque()
    {
        decimal vtotal=0;

        
        Console.WriteLine($"Valor total em estoque {vtotal}");
    }*/
    public void VerProduto()
    {
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}\nPreco: {produto.Preco}\nEm estoque: {produto.Estoque}");
        }
    }
}