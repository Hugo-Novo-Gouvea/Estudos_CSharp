//Exemplo 1
/*using System;
using System.IO; // <--- OBRIGATÓRIO: Biblioteca de Arquivos

namespace Aula_10;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== DIÁRIO DIGITAL ===");

        // 1. Definimos o nome do arquivo
        string caminhoArquivo = "meu_diario.txt";

        // 2. LER: Verificamos se o arquivo já existe para mostrar o histórico
        if (File.Exists(caminhoArquivo))
        {
            Console.WriteLine("\n--- Histórico de Anotações ---");
            // Lê TUDO o que tem no arquivo de uma vez e joga numa string
            string conteudo = File.ReadAllText(caminhoArquivo);
            Console.WriteLine(conteudo);
            Console.WriteLine("------------------------------");
        }
        else
        {
            Console.WriteLine("(Nenhum registro anterior encontrado. Criando novo arquivo...)");
        }

        // 3. ESCREVER: Pedimos algo novo
        Console.Write("\nDigite como foi seu dia (ou ENTER para sair): ");
        string novaEntrada = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(novaEntrada)) // Só salva se escreveu algo
        {
            // Adiciona a data e hora automaticamente pra ficar chique
            string textoFormatado = $"{DateTime.Now}: {novaEntrada}\n";

            // O Mágico AppendAllText:
            // Se o arquivo não existe, ele cria.
            // Se já existe, ele escreve NO FINAL (não apaga o que tinha antes).
            File.AppendAllText(caminhoArquivo, textoFormatado);

            Console.WriteLine("\n✅ Salvo no disco com sucesso!");
        }
        else
        {
            Console.WriteLine("\nNada foi salvo.");
        }

        Console.ReadKey();
    }
}*/

//Exemplo 2
using System;
using System.IO;
using System.Text.Json; // <--- O MÁGICO DO JSON (Novo no .NET)

namespace Aula_10;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string caminhoArquivo = "config_jogo.json";
        Configuracao minhaConfig;

        // --- PARTE 1: TENTAR CARREGAR (DESERIALIZAR) ---
        if (File.Exists(caminhoArquivo))
        {
            Console.WriteLine("📂 Arquivo de configuração encontrado! Carregando...");
            
            // 1. Lê o texto puro do arquivo
            string jsonTexto = File.ReadAllText(caminhoArquivo);
            
            // 2. Transforma TEXTO -> OBJETO C#
            minhaConfig = JsonSerializer.Deserialize<Configuracao>(jsonTexto);
            
            Console.WriteLine($"Bem-vindo de volta, {minhaConfig.NomeJogador}!");
            Console.WriteLine($"Nível Atual: {minhaConfig.NivelDificuldade}");
            Console.WriteLine($"Último Acesso: {minhaConfig.UltimoAcesso}");
        }
        else
        {
            Console.WriteLine("🆕 Nenhum arquivo encontrado. Criando configuração padrão...");
            minhaConfig = new Configuracao();
            minhaConfig.NomeJogador = "Player 1";
            minhaConfig.NivelDificuldade = 1;
            minhaConfig.SomAtivado = true;
        }

        Console.WriteLine("\n--------------------------------");
        
        // --- PARTE 2: MODIFICAR ---
        Console.Write("Deseja mudar o nível de dificuldade? (S/N): ");
        string resposta = Console.ReadLine();

        if (resposta.ToUpper() == "S")
        {
            Console.Write("Digite o novo nível (1-10): ");
            int novoNivel = int.Parse(Console.ReadLine());
            minhaConfig.NivelDificuldade = novoNivel;
            Console.WriteLine("Nível atualizado!");
        }

        // Atualiza o horário
        minhaConfig.UltimoAcesso = DateTime.Now;

        // --- PARTE 3: SALVAR (SERIALIZAR) ---
        Console.WriteLine("\n💾 Salvando dados...");

        // Configuração opcional para deixar o JSON bonito (com indentação)
        var opcoes = new JsonSerializerOptions { WriteIndented = true };

        // 1. Transforma OBJETO C# -> TEXTO JSON
        string jsonParaSalvar = JsonSerializer.Serialize(minhaConfig, opcoes);

        // 2. Grava no disco
        File.WriteAllText(caminhoArquivo, jsonParaSalvar);

        Console.WriteLine("Dados salvos com sucesso! Veja o arquivo 'config_jogo.json'.");
        Console.ReadKey();
    }
}