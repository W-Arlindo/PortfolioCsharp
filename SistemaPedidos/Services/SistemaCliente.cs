using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.Marshalling;
using Pedidos.Models;
using Pedidos.UI;

namespace Pedidos.Services;

class SistemCliente
{
    MCliente menuc=new();

    //lista de clientes
    List<Cliente> clientes = new List<Cliente>();

    //passar metodo para class SistemaPedido
    //Verificar cliente existente ou nao
    public Cliente VerificarCliente(int id){

        //Verificar qual cliente esta sendo buscado
        foreach (Cliente cliente in clientes)
        {
            if(id == cliente.Id)
            {
                return cliente;
            }
        }
        throw new InvalidOperationException("Cliente nao encontrado");
    }
    
    //criando cliente
    public void CriarCliente()
    {
        Console.WriteLine("==== Criando Cliente ====");
        string n,e;
        int i;
        i=menuc.ReceberId();
        n=menuc.ReceberNome();
        e=menuc.ReceberEmail();
        
        adicionarcliente(new(i,n,e));

        Console.Clear();
    }
    
    //listar cliente
    public void ListarClientes()
    {
        Console.WriteLine("===== Clientes =====");
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"Id: {cliente.Id}");
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine("= = = = = =");
        }
        Console.WriteLine("...");
    }
   
    //adicionando novo cliente a lista
    void adicionarcliente(Cliente c)
    {
        clientes.Add(c);
    }

    //buscando cliente existente
    Cliente buscarcliente()
    {
        int i;
        ListarClientes();
        //VerClientes();
        Console.WriteLine("===");
        i = menuc.ReceberId();
        foreach(Cliente cliente in clientes)
        {
            if(i == cliente.Id)
            {
                return cliente;
            }
        }
        throw new InvalidOperationException("Cliente nao encontrado");
    }
}