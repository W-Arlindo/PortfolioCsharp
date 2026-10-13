using System;
using System.Collections.Generic;

namespace ex6;

abstract class Forma
{
    public string? Nome{get; private set;}
    public Forma(string? nome)
    {
        Nome=nome;
    }
    public abstract double CalcularArea();
}
class Retangulo : Forma
{
    public double altura{get; private set;}
    public double largura{get; private set;}
    public Retangulo(string? nome, double altura,double largura) : base(nome)
    {
        this.altura = altura;
        this.largura= largura;
    }
    public override double CalcularArea()
    {
        return largura*altura;
    }
}
class Circulo : Forma
{
    public double raio{get;private set;}
    public Circulo(string? nome, double raio) : base(nome)
    {
        this.raio=raio;
    }
    public override double CalcularArea()
    {
        return Math.PI*raio*raio;
    }
}
class Program
{
    static void Main()
    {
        List<Forma> formas = new();
        formas.Add(new Circulo("Circulo",3));
        formas.Add(new Retangulo("Retangulo",3,5));
        formas.Add(new Circulo("Circulo", 9));
        formas.Add(new Retangulo("Retangulo", 9, 15));
        foreach (Forma forma in formas)
        {
            Console.WriteLine($"Nome: {forma.Nome} > Area: {forma.CalcularArea()}");
        }
    }
}