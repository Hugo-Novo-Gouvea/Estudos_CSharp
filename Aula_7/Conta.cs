using System;

namespace Aula_7;

public class Conta(string titular)
{
    public string Titular { get; set; } = titular;
    public decimal Saldo { get; protected set; } = 0;

    public void Depositar(decimal valor)
    {
        Saldo += valor;
        Console.WriteLine($"Depósito de {valor:C} na conta de {Titular}.");
    }

    public virtual void Sacar(decimal valor)
    {
        if(valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de {valor:C} efetuado.");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente."); 
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Conta: {Titular} | Saldo: {Saldo:C}.");
    }

}