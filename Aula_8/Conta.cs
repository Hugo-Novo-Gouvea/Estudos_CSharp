using System;

namespace Aula_8;

public abstract class Conta(string titular)
{
    public string Titular { get; set; } = titular;
    public decimal Saldo { get; protected set; } = 0;

    public virtual void Depositar(decimal valor)
    {
        Saldo += valor;
        Console.WriteLine($"Depósito de {valor:C} na conta de {Titular}.");
    }

    public abstract void Sacar(decimal valor);
    
    public void ExibirSaldo()
    {
        Console.WriteLine($"Conta: {Titular} | Saldo: {Saldo:C}.");
    }

}