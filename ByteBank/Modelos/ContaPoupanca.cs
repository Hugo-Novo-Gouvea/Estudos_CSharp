using System;

namespace ByteBank.Modelos;

public class ContaPoupanca(int numero, Cliente titular): ContaCorrente(numero, titular)
{
    public override void Sacar(decimal valor)
    {
        if (Saldo >= valor)
        {
            Saldo -= valor;
            Console.WriteLine($"💰 Saque de {valor:C} realizado na Poupança. Saldo atual: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("❌ Saldo insuficiente.");
        }
    }

    public void RenderJuros()
    {
        decimal juros = Saldo + 0.05m;
        Saldo += juros;
        Console.WriteLine($"📈 Rendimento de {juros:C} aplicado!");
    }
}