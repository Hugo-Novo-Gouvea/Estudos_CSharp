using System;

namespace Aula_8;

public class ContaPoupanca(string titular) : Conta(titular)
{

    public override void Sacar(decimal valor)
    {
        // Poupança não tem taxa, mas agora precisa ser explícita
        if (valor <= this.Saldo)
        {
            this.Saldo -= valor;
            Console.WriteLine($"Saque de {valor:C} na Poupança.");
        }
    }

    public void RenderJuros()
    {
        decimal juros = this.Saldo * 0.05m;
        this.Saldo += juros;
        Console.WriteLine($"Rendimento de {juros:C} aplicado na poupança.");
    }
}