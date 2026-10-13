using System;

namespace ex7;

interface IInteragivel
{
    public void Interagir();
}
class NPC:IInteragivel
{
    public void Interagir()
    {
        Console.WriteLine("Hi, Good Mooning, How are you?");
    }
}
class Porta : IInteragivel
{
    public void Interagir()
    {
        Console.WriteLine("Porta foi aberta");
    }
}
class Bau : IInteragivel
{
    public void Interagir()
    {
        Console.WriteLine("Bau sendo aberto");
    }
}
class Program
{
     static void Main()
    {
        List<IInteragivel> interagivels=new();
        interagivels.Add(new Bau());
        interagivels.Add(new Porta());
        interagivels.Add(new NPC());

        foreach(IInteragivel inter in interagivels)
        {
            inter.Interagir();
        }
    }
}