using System;

namespace ex3;

class Personagem
{
    public string? Nome{get; private set;}
    public int Vida{get; private set;}

    public Personagem(string? nome)
    {
        Nome=nome;
        Vida=100;
    }
    public void ReceberDano(int dano)
    {
        if (dano > 0 && dano <= Vida)
        {
            Vida -=dano;
        }
        else if(dano >= Vida)
        {
            Vida =0;
        }
    }
}
class Program
{
    static void Main()
    {
        Personagem personagem = new Personagem("Guerreiro");

        personagem.ReceberDano(70);
    }
}