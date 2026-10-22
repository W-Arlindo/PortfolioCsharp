using System;

namespace ex11;

struct Dimensoes{
    public double Largura{get; private set;}
    public double Altura{get; private set;}
    public double Profundidade{get; private set;}
    
    public Dimensoes(double largura, double altura, double profundidade){
        if(Verificar(largura)){
            Largura = largura;
        }
        if(Verificar(altura)){
            Altura=altura;
        }
        if(Verificar(profundidade)){
            Profundidade = profundidade;
        }
    }
    
    bool Verificar(Double v){
        if(v <= 0){
            throw new ArgumentException("Valor invalido");
        }
        else {
            return true;
        }
    }
    public double Calcular(){
        return Largura*Profundidade*Altura;
    }
    
    public void AlterarAltura(double v){
        if(Verificar(v)){
            Altura = v;
        }
    }
    public void AlterarLargura(double v){
        if(Verificar(v)){
            Largura = v;
        }
    }
    public void AlterarProfundidade(double v){
        if(Verificar(v)){
            Profundidade = v;
        }
    }
}
class Program{
    static void Main(){
        Dimensoes d1 = new Dimensoes(10,15,5);
        Dimensoes d2 = d1;
        
        d2.AlterarLargura(20);
        if(d2.Calcular() == d1.Calcular()){
            Console.WriteLine($"Ambos possuem o mesmo perimetro {d1.Calcular()} == {d2.Calcular()}");
        }
        
        Console.WriteLine(d1.Calcular());
        Console.WriteLine(d2.Calcular());
    }
}