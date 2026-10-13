using System;

namespace Pedidos.Models;

interface IPagamento
{
    void Pagar(decimal valor);
}
interface IFalha
{
    string mensfalha(string motivo);
}
