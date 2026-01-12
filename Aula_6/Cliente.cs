using System;

namespace Aula_6;

public class Cliente(string nome, string cpf)
{
    public string Nome { get; set; } = nome;
    public string Cpf { get; set; } = cpf;
    public decimal Saldo { get; private set; } = 0;

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if(valor <= Saldo)
        {
            Saldo -= valor;    
        }
        else
        {
            Console.WriteLine("Operação não disponivel: Valor digitado é maior que o saldo atual");
        }
        
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome} | CPF: {Cpf} | Saldo: {Saldo}");
    }
}