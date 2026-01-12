using System;
using System.Collections.Generic;

namespace Aula_8;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA DE TRIBUTAÇÃO ===");

        // 1. Criando objetos
        ContaCorrente cc = new ContaCorrente("Hugo Rico");
        cc.Depositar(1000); // Saldo 1000 -> Imposto deve ser 50 (5%)

        ContaPoupanca cp = new ContaPoupanca("Ana Economista");
        cp.Depositar(1000); // Poupança não paga imposto.

        SeguroDeVida sv = new SeguroDeVida(); // Seguro paga 50 fixo.

        // 2. O Grande Teste da Interface
        // Vamos criar uma lista de COISAS TRIBUTÁVEIS.
        // A Poupança NÃO entra aqui porque ela não tem o contrato (badge) ITributavel.
        
        List<ITributavel> listaDeTributos = new List<ITributavel>();
        
        listaDeTributos.Add(cc); // Conta Corrente entra (é Conta e é Tributável)
        listaDeTributos.Add(sv); // Seguro entra (não é Conta, mas é Tributável)
        // listaDeTributos.Add(cp); // ERRO! Poupança não é ITributavel.

        // 3. Calculando o total que o governo vai levar
        decimal totalImposto = 0;

        foreach(ITributavel item in listaDeTributos)
        {
            // O Polimorfismo acontece aqui via Interface
            decimal valor = item.CalcularImposto();
            Console.WriteLine($"Item tributado. Valor: {valor:C}");
            totalImposto += valor;
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine($"Total arrecadado pelo governo: {totalImposto:C}");

        // 4. Teste do Abstract (Tente descomentar a linha abaixo para ver o erro)
        // Conta contaGen = new Conta("Fantasma"); // ERRO CS0144: Cannot create an instance of the abstract class

        Console.ReadKey();
    }
}