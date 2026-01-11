using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula_5;

class Program
{
    static void Main(string[] args)
    {
        string cpfBusca;
        
        // CORREÇÃO 1: O '?' diz que essa variável aceita ficar vazia (null) se não achar nada.
        Cliente? clienteEncontrado; 
        
        // Sintaxe moderna de inicialização de lista (C# 12+)
        List<Cliente> listaDoBanco = [];

        // CORREÇÃO 2: Usamos 'new Cliente(...)' para criar o objeto antes de adicionar
        listaDoBanco.Add(new Cliente("Hugo", "111.222.333-44"));
        listaDoBanco.Add(new Cliente("Ana", "999.888.777-66"));
        listaDoBanco.Add(new Cliente("Junior", "444.555.666-77"));

        Console.Clear();
        Console.WriteLine("=== RELATÓRIO GERAL DO BANCO ===");

        foreach(Cliente cliente in listaDoBanco)
        {
            cliente.ExibirDados();
        }

        Console.WriteLine("================================");
        Console.WriteLine("\n=== ÁREA DE TRANSAÇÃO ===");
        Console.Write("Digite o CPF do cliente para depositar: ");
        cpfBusca = Console.ReadLine() ?? "";

        // LINQ
        clienteEncontrado = listaDoBanco.Find(c => c.Cpf == cpfBusca);     

        if (clienteEncontrado != null)
        {
            Console.WriteLine($"\nCliente Localizado: {clienteEncontrado.Nome}");
            Console.Write("Qual valor deseja depositar? R$ ");
            
            // Proteção simples contra nulo no Parse
            string valorTexto = Console.ReadLine() ?? "0";
            decimal valor = decimal.Parse(valorTexto);
            
            clienteEncontrado.Depositar(valor);

            Console.WriteLine("\n--- Status Atualizado ---");
            clienteEncontrado.ExibirDados();
        }
        else
        {
            Console.WriteLine("\n[ERRO] Cliente não encontrado. Verifique o CPF digitado.");
        }
        
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}