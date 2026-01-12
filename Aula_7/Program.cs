using System;
using System.Collections.Generic;

namespace Aula_7;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== BANCO POLIMÓRFICO ===");

        // 1. Criando uma Conta Corrente (Filho 1)
        ContaCorrente c1 = new ContaCorrente("Hugo (Corrente)");
        c1.Depositar(100); // Herdou do Pai
        c1.Sacar(10);      // Usou o Override (Vai cobrar taxa de R$ 2,00)
        c1.ExibirSaldo();  // Deve sobrar 88 (100 - 10 - 2)

        Console.WriteLine("-------------------------");

        // 2. Criando uma Conta Poupança (Filho 2)
        ContaPoupanca c2 = new ContaPoupanca("Ana (Poupança)");
        c2.Depositar(100); // Herdou do Pai
        c2.Sacar(10);      // Usou o Padrão do Pai (Sem taxa)
        c2.RenderJuros();  // Método exclusivo
        c2.ExibirSaldo();  // Deve ter (100 - 10) + 5% = 90 + 4,50 = 94,50

        Console.ReadKey();
    }
}
