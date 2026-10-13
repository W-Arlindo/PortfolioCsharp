using System;
using Pedidos.Services;
using Pedidos.Models;

namespace Pedidos.UI;
class MPedido
{
    public int ReceberNumero()
    {
        Console.Write("Numero do Pedido: ");
        return int.Parse(Console.ReadLine());
    }
    public int ReceberQ()
    {
        Console.Write("Quantidade: ");
        return int.Parse(Console.ReadLine());
    }
    public int ReceberIdCliente()
    {
        Console.Write("ID do cliente: ");
        return int.Parse(Console.ReadLine());
    }
    public int ReceberIdProduto()
    {
        Console.Write("Id do Produto: ");
        return int.Parse(Console.ReadLine());
    }

}
class MProduto
{
    public int ReceberId()
    {
        Console.Write("Id: ");
        return int.Parse(Console.ReadLine());
    }
    public string ReceberNome()
    {
        Console.Write("Nome Produto: ");
        return Console.ReadLine();
    }
    public decimal ReceberPreco()
    {
        Console.Write("Preco: R$");
        return decimal.Parse(Console.ReadLine());
    }
    
}
class MCliente
{
    public int ReceberId()
    {
        Console.Write("Id: ");
        return int.Parse(Console.ReadLine());
    }
    public string ReceberNome()
    {
        Console.Write("Nome: ");
        return Console.ReadLine();
    }
    public string ReceberEmail()
    {
        Console.Write("Email: ");
        return Console.ReadLine();
    }
    public void VerficarCliente()
    {
        Console.WriteLine("======");
        Console.Write("1-sim\n2-nao\nCliente ja existente: ");
    }
}
class Pagamento
{
    public int VerificicarPagamento()
    {
        Console.WriteLine("Forma de pagamento\n\n");

        Console.WriteLine("1 - Pix");
        Console.WriteLine("2 - Cartao\n\n");

        return int.Parse(Console.ReadLine());
    }
}
class Menu
{
    
    public SistemCliente scliente = new SistemCliente();
    public SistemProduto sproduto = new SistemProduto();

    SistemaPedidos spedido;
    
    public Menu()
    {
        spedido = new SistemaPedidos(scliente,sproduto);
    }
     
    
    bool Tela()
    {
        bool p = true;
        int opcao=0;
        
        Console.WriteLine("1 - Cadastrar cliente");
        Console.WriteLine("2 - Listar clientes");
        Console.WriteLine("3 - Cadastrar produto");
        Console.WriteLine("4 - Listar produtos");
        Console.WriteLine("5 - Criar pedido");
        Console.WriteLine("6 - Listar pedidos");
        Console.WriteLine("7 - Finalizar pedido");
        Console.WriteLine("0 - Sair");
        opcao = int.Parse(Console.ReadLine());
        Console.Clear();
        switch (opcao)
        {
            case 1:
                scliente.CriarCliente();
            break;
            case 2:
                scliente.ListarClientes();
            break;
            case 3:
                sproduto.CadastrarProduto();
            break;
            case 4:
                sproduto.ListarProdutos();
            break;
            case 5:
                spedido.CriarPedido();
            break;
            case 6:
                spedido.ListarPedidos();
            break;
            case 7:
                spedido.FinalizarCompra();
            break;
            case 0:
                p = false;
            break;
        }
        return p;
    }
    public bool __init__()
    {
        bool programa = true;
        programa = Tela();
        return programa;
    }
}