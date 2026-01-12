/*
using System;

namespace Aula_7;

public class ContaCorrente: Conta
{
    public ContaCorrente(string titular) : base(titular)
    {
        
    }

    public override void Sacar(decimal valor)
    {
        decimal taxa = 2.00m;
        decimal totalSaque = valor + taxa;

        if (totalSaque <= this.Saldo)
        {
            this.Saldo += totalSaque;
            Console.WriteLine($"Saque de {valor:C} realizado. Taxa de {taxa:C} cobrada.");
        }
        else
        {
            Console.WriteLine($"Saldo insuficiente para saque + taxa ({totalSaque:C}).");
        }
    }
}
*/