using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading; // Para dar pausas dramáticas (Thread.Sleep)
using ByteBank.Modelos;

namespace ByteBank;

class Program
{
    // LISTA GLOBAL: Onde todas as contas vivem enquanto o programa roda
    static List<ContaCorrente> listaDeContas = new List<ContaCorrente>();
    
    // Caminho do arquivo
    static string caminhoArquivo = "banco_dados.json";

    static void Main(string[] args)
    {
        CarregarDados(); // 1. Tenta ler o JSON ao abrir

        string opcao = "";

        // 2. O Loop Infinito do Menu Principal
        while (opcao != "4")
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("    🏦 BEM-VINDO AO BYTEBANK    ");
            Console.WriteLine("===============================");
            Console.WriteLine("1 - Criar Nova Conta");
            Console.WriteLine("2 - Acessar Conta (Login)");
            Console.WriteLine("3 - Listar Todas as Contas (Admin)");
            Console.WriteLine("4 - Sair e Salvar");
            Console.WriteLine("===============================");
            Console.Write("Digite a opção desejada: ");
            
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CadastrarConta(); break;
                case "2": Logar(); break;
                case "3": ListarContas(); break;
                case "4": 
                    SalvarDados(); // 3. Salva no JSON ao sair
                    Console.WriteLine("Saindo... Bom café! ☕"); 
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1000); // Espera 1 segundinho
                    break;
            }
        }
    }

    // --- FUNÇÕES DO MENU ---

    static void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("=== ABERTURA DE CONTA ===");
        
        Console.Write("Digite o Nome do Cliente: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();

        // Gerador de número de conta aleatório (1000 a 9999)
        int numeroConta = new Random().Next(1000, 9999);

        // Criando os Objetos
        Cliente novoCliente = new Cliente(nome, cpf, "123"); // Senha padrão 123 pra facilitar
        ContaCorrente novaConta = new ContaCorrente(numeroConta, novoCliente);

        // Adicionando na Lista Global
        listaDeContas.Add(novaConta);

        Console.WriteLine("\n✅ Conta Criada com Sucesso!");
        Console.WriteLine($"Número da Conta: {numeroConta}");
        Console.WriteLine($"Titular: {nome}");
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    static void Logar()
    {
        Console.Clear();
        Console.WriteLine("=== ACESSAR CONTA ===");
        Console.Write("Digite o CPF do Titular: ");
        string cpfBusca = Console.ReadLine();

        // BUSCA AVANÇADA (LAMBDA): Procura na lista alguém com esse CPF
        // Se não souber Lambda, imagine que é um 'foreach' que retorna o primeiro que achar
        ContaCorrente contaEncontrada = listaDeContas.Find(c => c.Titular.Cpf == cpfBusca);

        if (contaEncontrada != null)
        {
            MenuDaConta(contaEncontrada);
        }
        else
        {
            Console.WriteLine("❌ Cliente não encontrado!");
            Thread.Sleep(2000);
        }
    }

    static void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("=== RELATÓRIO DE CONTAS ===");
        if(listaDeContas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
        }
        else
        {
            foreach(var conta in listaDeContas)
            {
                Console.WriteLine($"Conta: {conta.NumeroConta} | Titular: {conta.Titular.Nome} | Saldo: {conta.Saldo:C}");
            }
        }
        Console.WriteLine("\nEnter para voltar...");
        Console.ReadKey();
    }

    // --- SUB-MENU (QUANDO O CLIENTE LOGA) ---

    static void MenuDaConta(ContaCorrente conta)
    {
        string opcao = "";
        while (opcao != "0")
        {
            Console.Clear();
            Console.WriteLine($"👤 Olá, {conta.Titular.Nome}!");
            Console.WriteLine($"💰 Saldo Atual: {conta.Saldo:C}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("0 - Voltar (Logout)");
            Console.Write("O que deseja fazer? ");
            opcao = Console.ReadLine();

            try // BLINDAGEM CONTRA NÚMEROS ERRADOS
            {
                switch (opcao)
                {
                    case "1":
                        Console.Write("Valor do depósito: ");
                        decimal vDep = decimal.Parse(Console.ReadLine());
                        conta.Depositar(vDep);
                        break;
                    case "2":
                        Console.Write("Valor do saque: ");
                        decimal vSaq = decimal.Parse(Console.ReadLine());
                        conta.Sacar(vSaq);
                        break;
                    case "3":
                        Console.Write("Valor da transferência: ");
                        decimal vTransf = decimal.Parse(Console.ReadLine());
                        Console.Write("CPF do Destinatário: ");
                        string cpfDest = Console.ReadLine();
                        
                        // Busca quem vai receber
                        var destino = listaDeContas.Find(c => c.Titular.Cpf == cpfDest);
                        
                        if(destino != null)
                        {
                            conta.Transferir(vTransf, destino);
                        }
                        else
                        {
                            Console.WriteLine("Destinatário não encontrado.");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Fazendo Logout...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro na operação: {ex.Message}");
            }
            
            if(opcao != "0") 
            {
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadKey();
            }
        }
    }

    // --- PERSISTÊNCIA (SALVAR E CARREGAR) ---

    static void SalvarDados()
    {
        try 
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(listaDeContas, options);
            File.WriteAllText(caminhoArquivo, json);
            Console.WriteLine("💾 Dados salvos no disco!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar: {ex.Message}");
        }
    }

    static void CarregarDados()
    {
        try
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                listaDeContas = JsonSerializer.Deserialize<List<ContaCorrente>>(json);
                Console.WriteLine("📂 Dados carregados com sucesso!");
                Thread.Sleep(1000);
            }
        }
        catch
        {
            Console.WriteLine("Nenhum dado anterior encontrado ou arquivo corrompido.");
            listaDeContas = new List<ContaCorrente>();
        }
    }
}