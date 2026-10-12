using System;

namespace ex4;

class Animal
{
    public string? Nome{get; private set;}
    public int Idade{get; private set;}
    public Animal(string? nome, int idade)
    {
        Nome=nome;
        Idade=idade;
    }

    public virtual void EmitirSom()
    {
        
    }
}
class Cachorro : Animal
{
    public Cachorro(string? nome,int idade):base(nome, idade){
    }
    public override void EmitirSom()
    {
        Console.WriteLine("Auu Auu");
    }
}
class Gato : Animal
{
    public Gato(string? nome,int idade):base(nome,idade){
    }
    public override void EmitirSom()
    {
        Console.WriteLine("Miau Miau");
    }
}
class Program
{
   
    static void Main()
    {
        List<Animal> animais=new List<Animal>();
        animais.Add(new Cachorro("rex",2));
        animais.Add(new Gato("smygle",1));
        animais.Add(new Cachorro("pit",2));
        animais.Add(new Gato("ma",1));
        foreach(var animal in animais)
        {
            animal.EmitirSom();
        }
    }
}