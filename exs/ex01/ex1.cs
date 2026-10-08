using System;
using System.Collections.Generic;
 
 namespace ex01;

 class Aluno
{
    public string Nome{get; private set;}
    public int Idade{get; private set;}
    public double Nota{get; private set;}
    
    public Aluno(string nome, int i, double n)
    {
        Nome = nome;
        Idade = i;
        Nota = n;
    }
}
class Sistem
{
    List<Aluno> alunos = new List<Aluno>();

    Aluno aluno1 = new Aluno("Jota",17, 7.3);
    Aluno aluno2 = new Aluno("Gusta", 14, 5.3);

    public void AdicionarLista()
    {
        alunos.Add(aluno1);
        alunos.Add(aluno2);
    }
    public void ExibirInformacoes()
    {
        foreach(var aluno in alunos)
        {
            Console.WriteLine($"Nome: {aluno.Nome}\nIdade: {aluno.Idade}\nNota: {aluno.Nota}\n\n");
        }
    }
}
class Program
{
    
    public static void Main()
    {
        Sistem Metodos = new Sistem();
        Metodos.AdicionarLista();
        Metodos.ExibirInformacoes(); 
    }
}
