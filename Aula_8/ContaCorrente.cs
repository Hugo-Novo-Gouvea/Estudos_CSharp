using System;

namespace Aula_8;

public class ContaCorrente(string titular) : Conta(titular), ITributavel
{
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

    // OBRIGATÓRIO: Já que assinou o contrato ITributavel, tem que implementar isso:
    public decimal CalcularImposto()
    {
        // Regra de negócio: O imposto é 5% do saldo atual
        return this.Saldo * 0.05m;
    }
}