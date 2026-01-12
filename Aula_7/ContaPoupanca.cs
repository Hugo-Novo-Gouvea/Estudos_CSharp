using System;

namespace Aula_7;

public class ContaPoupanca(string titular) : Conta(titular)
{

    public void RenderJuros()
    {
        decimal juros = this.Saldo * 0.05m;
        this.Saldo += juros;
        Console.WriteLine($"Rendimento de {juros:C} aplicado na poupança.");
    }
}