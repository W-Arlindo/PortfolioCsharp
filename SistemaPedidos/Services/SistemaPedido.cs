using System;
using System.Dynamic;
using Pedidos.Models;
using Pedidos.UI;

namespace Pedidos.Services;

class SistemaPedidos
{
    SistemCliente scliente;
    SistemProduto sproduto;
    public SistemaPedidos(SistemCliente sc, SistemProduto sp)
    {
        scliente=sc;
        sproduto=sp;

    }
    
    MPedido mpedido = new();

    List<Pedido> pedidos = new List<Pedido>();
    
    Pagamento formapg = new();
    
    //Cadastrando novo pedido
    public void CriarPedido()
    {
        int n,q;
        Console.WriteLine("===== Criando Pedido =====");
        n=mpedido.ReceberNumero();

        scliente.ListarClientes();
        Cliente c = scliente.VerificarCliente(mpedido.ReceberIdCliente());

        sproduto.ListarProdutos();
        Produto p = sproduto.VerificarProduto(mpedido.ReceberIdProduto());

        q = mpedido.ReceberQ();
        adicionarlista(new Pedido(c,p,q,n));
    }
    
    //adicionando novo produto a lista
    void adicionarlista(Pedido p)
    {
        pedidos.Add(p);
    }
    //Lista pedido conforme o cliente
    public void ListarPedidos()
    {
        Console.WriteLine("========== PEDIDOS ==========");
        foreach(Pedido pedido in pedidos)
        {
            Console.WriteLine($"Pedido: {pedido.Numero}");
            Console.WriteLine($"Cliente: {pedido.cliente.Nome}");
            Console.WriteLine($"Produto: {pedido.produto.Nome}");
            Console.WriteLine($"Quantidade: {pedido.Quantidade}");
            Console.WriteLine($"Valor Total: R${pedido.Vtotal}");
            Console.WriteLine("= = = = = =");
        }
    }
    bool verificarpedido(int n)
    {
        foreach (Pedido pedido in pedidos)
        {
            if (n == pedido.Numero)
            {
                return true;
            }
        }
        throw new InvalidOperationException("Pedido nao encontrado");
    }
    //finalizar compra
    public void FinalizarCompra()
    {
        ListarPedidos();
        Pedido _ = null;

        int np = mpedido.ReceberNumero();

        if (verificarpedido(np))
        {
            foreach(Pedido p in pedidos)
            {
                if(np == p.Numero)
                {
                    _ = p;
                }
            }
            if(!_.CompraRealizada)
            {
                switch (formapg.VerificicarPagamento())
                {
                    case 1:
                        new Pix().Pagar(_.Vtotal);
                    break;
                    case 2:
                        new Cartao().Pagar(_.Vtotal);
                    break;
                    default:
                    throw new InvalidOperationException("Escolha invalida");
                }
                _.Comprado();
            }
            else
            {
                Console.WriteLine("Compra ja realizada");
                return;
            }
        }
    }
}