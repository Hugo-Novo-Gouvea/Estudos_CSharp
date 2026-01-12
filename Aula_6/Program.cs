using System;
using System.Collections.Generic;

namespace Aula_6;

class Program
{
    static void Main(string[] args)
    {
        string cpfDigitado;
        Cliente? clienteEncontrado;

        Banco meuBanco = new Banco();
        
        meuBanco.AdicionarCliente(new Cliente("Hugo", "111.222.333-44"));
        meuBanco.AdicionarCliente(new Cliente("Ana", "999.888.777-66"));
        meuBanco.AdicionarCliente(new Cliente("Bob", "555.444.333-22"));

        Console.Clear();
        Console.WriteLine("=== RELATÓRIO DO BANCO ===");

        foreach(Cliente cliente in meuBanco.ObterTodosClientes())
        {
            cliente.ExibirDados();
        }

        Console.WriteLine("\n=== ÁREA DE TRANSAÇÃO ===");
        Console.Write("Digite o CPF para depósito: ");
        cpfDigitado = Console.ReadLine() ?? "";

        clienteEncontrado = meuBanco.BuscarPorCpf(cpfDigitado);

        if(clienteEncontrado != null)
        {
            Console.WriteLine($"\nCliente Localiza: {clienteEncontrado.Nome}");
            Console.Write("Valor do depósito: R$ ");

            string inputValor = Console.ReadLine() ?? "0";
            decimal valor = decimal.Parse(inputValor);

            clienteEncontrado.Depositar(valor);

            Console.WriteLine("Sucesso! Saldo atualizado.");
            clienteEncontrado.ExibirDados();
        }
        else
        {
            Console.WriteLine("[ERRO] Cliente não encontrado no sistema.");
        }

        Console.ReadKey();
    }
}
