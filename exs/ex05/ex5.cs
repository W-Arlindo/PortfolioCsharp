using System;

namespace ex5;

class Funcionario
{
    public string? Nome
    {
        get; private set;
    }
    public decimal Salario
    {
        get;protected set;
    }
    public Funcionario(string? nome,decimal salario)
    {
        Nome=nome;
        Salario=salario;
    }
    public virtual void ExibirCargo()
    {
        Console.Write("Cargo: ");
    }
}
class Gerente : Funcionario
{
    public Gerente(string? nome,decimal salario) : base(nome,salario){}
    public override void ExibirCargo()
    {
        base.ExibirCargo();
        Console.WriteLine("Gerente");
    }
}
class Programador : Funcionario
{
    public Programador(string? nome,decimal salario) : base(nome,salario){}
    public override void ExibirCargo()
    {
        base.ExibirCargo();
        Console.WriteLine("Programador");
    }
}
class Program
{
    static void Main()
    {
        Programador p = new Programador("Pp",1780);
        Gerente g = new Gerente("Gg",2500);
        p.ExibirCargo();
        g.ExibirCargo();
    }
}