using System;

namespace ByteBank.Modelos;

public abstract class ContaBancaria(int numero, Cliente titular)
{
    public int NumeroConta { get; set; } = numero;
    public decimal Saldo { get; protected set; } = 0;
    public Cliente Titular { get; set; } = titular;

    public virtual void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"✅ Depósito de {valor:C} realizado na conta {NumeroConta}.");
        }
        else
        {
            Console.WriteLine("❌ Valor inválido para depósito.");
        }
    }

    public abstract void Sacar(decimal valor);

    public void Transferir(decimal valor, ContaBancaria destino)
    {
        if (valor <= Saldo)
        {
            this.Sacar(valor);
            destino.Depositar(valor);
            Console.WriteLine($"🔄 Transferência de {valor:C} para {destino.Titular.Nome} realizada!");
        }
        else
        {
            Console.WriteLine("❌ Saldo insuficiente para transferência.");
        }
    }

}