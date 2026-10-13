using System;
using Loja.Services;

namespace Loja.UI;

class Menu()
{
    public Sistem Loja=new Sistem();
    public bool continua = true;
    public void SistemaProduto()
    {
        
        int opcao;
        Console.WriteLine("=== SISTEMA DE PRODUTOS ===\n");
        Console.WriteLine("1 - Cadastrar produto");
        Console.WriteLine("2 - Adicionar estoque");
        Console.WriteLine("3 - Remover estoque");
        Console.WriteLine("4 - Alterar preco");
        Console.WriteLine("5 - Exibir produto");
        Console.WriteLine("6 - Sair");
        Console.Write("Escolha: ");
        opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
            Console.Clear();
            Loja.CadastrarProdutos();
            break;

            case 2:
            Console.Clear();
            Loja.VerProduto();
            Console.Write("Adicionar qual: ");
            Loja.AdicionarEstoque(Console.ReadLine());
            break;

            case 3:
            Console.Clear();
            Loja.VerProduto();
            Console.Write("Remover qual: ");
            Loja.RemoverEstoque(Console.ReadLine());
            break;

            case 4:
            Console.Clear();
            Loja.VerProduto();
            Console.Write("Qual: ");
            Loja.AlterarPreco(Console.ReadLine());
            break;
            case 5:
            Console.Clear();
            Loja.VerProduto();
            Console.ReadKey();
            break; 
            case 6:
            continua=false;
            break;
            
            

        }
    }
}