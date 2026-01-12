using System;

namespace ByteBank.Modelos;

public class ContaCorrente(int numero, Cliente titular): ContaBancaria(numero, titular)
{
    public override void Sacar(decimal valor)
    {
        decimal taxa = 1.00m;
        decimal totalSaque = valor + taxa;

        if (Saldo >= totalSaque)
        {
            Saldo -= totalSaque;
            Console.WriteLine($"💸 Saque de {valor:C} realizado (Taxa: {taxa:C}). Saldo atual: {Saldo:C}");
        }
        else
        {
            Console.WriteLine($"❌ Saldo insuficiente para sacar {valor:C} + taxas.");
        }
    }
}