//Exemplo 1
/*using System;

namespace Aula_9;

class Program
{
    static void Main(string[] args)
    {
        // Console.Clear(); // Comentei pra não bugar seu debug se usar
        
        try 
        {
            // --- ÁREA DE RISCO (TRY) ---
            // Tudo que pode dar erro fica aqui dentro.
            
            Console.Write("Digite um número: ");
            int numero1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o divisor: ");
            int numero2 = int.Parse(Console.ReadLine());

            int resultado = numero1 / numero2;
            Console.WriteLine($"Resultado: {resultado}");
        }
        catch (DivideByZeroException)
        {
            // Captura específica para divisão por zero
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("[ERRO] Não é possível dividir por zero, meu jovem.");
        }
        catch (FormatException)
        {
            // Captura específica para letras no lugar de números
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("[ERRO] Você digitou letras? Eu pedi números!");
        }
        catch (Exception ex)
        {
            // O "Pega-Tudo". Captura qualquer outro erro que a gente não previu.
            // A variável 'ex' contém os detalhes técnicos do erro.
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"[ERRO CRÍTICO] Aconteceu algo bizarro: {ex.Message}");
        }
        finally
        {
            // Opcional: Roda SEMPRE. Útil para dar tchau ou fechar arquivos.
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Fim da operação (passando pelo Finally).");
        }

        Console.WriteLine("O programa continua vivo aqui embaixo!");
        Console.ReadKey();
    }
}*/

//Exemplo 2
/*using System;

namespace Aula_9;

class Program
{
    static void Main(string[] args)
    {
        // Variável criada fora do Try para ser usada depois
        int numeroEscolhido = 0; 
        bool entradaValida = false;

        Console.WriteLine("=== SISTEMA DE CADASTRO ===");

        // ENQUANTO a entrada NÃO for válida, repita.
        while (entradaValida == false)
        {
            try
            {
                Console.Write("Por favor, digite sua idade: ");
                string input = Console.ReadLine();
                
                // Se der erro aqui na linha debaixo, ele pula pro CATCH imediatamente
                numeroEscolhido = int.Parse(input);

                // Se chegou aqui, é porque deu certo!
                entradaValida = true; // Isso vai quebrar o loop
            }
            catch (FormatException)
            {
                Console.WriteLine("❌ Erro: Você digitou letras! Tente apenas números.");
                // O loop continua e pergunta de novo...
            }
            catch (Exception)
            {
                Console.WriteLine("❌ Erro desconhecido. Tente novamente.");
            }
        }

        Console.WriteLine($"✅ Sucesso! Idade cadastrada: {numeroEscolhido}");
        Console.ReadKey();
    }
}*/