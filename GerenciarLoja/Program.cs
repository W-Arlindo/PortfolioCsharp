using System;
using System.Security.Cryptography;
using Loja.UI;

namespace Loja;

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        bool c;

        do{
            menu.SistemaProduto();
            c = menu.continua;
        }while(c);
        
        
    }
}

