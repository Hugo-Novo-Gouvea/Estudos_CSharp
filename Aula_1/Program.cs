string nome;
int opcao;

Console.Write("Bem vindo ao Banco! Por favor, informe seu nome: ");
nome = Console.ReadLine() ?? "";

do 
{
    Console.Clear();
    
    Console.WriteLine("======================================");
    Console.WriteLine("======= AUTO-ATENDIMENTO BANCO =======");
    Console.WriteLine("======================================");
    Console.WriteLine("=                                    =");
    Console.WriteLine("=        1 - Contratar Plano         =");
    Console.WriteLine("=        2 - Suporte Técnico         =");
    Console.WriteLine("=        3 - Financeiro              =");
    Console.WriteLine("=        4 - Sair                    =");
    Console.WriteLine("=                                    =");
    Console.WriteLine("======================================");
    Console.WriteLine("");
    Console.Write("Informe a opção desejada: ");

    while(!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0)
    {
        Console.WriteLine("Opção Invalida... Tente Novamente");
        Console.Write("Informe a opção desejada: ");
    }

    switch(opcao)
    {
        case 1:
            Console.WriteLine("Redirecionando para setor de vendas...");
            break;
        case 2:
            Console.WriteLine("Enviando e-mail para suporte@dev.com...");
            break;
        case 3:
            Console.WriteLine("Consultando faturas em aberto...");
            break;
        case 4:
            Console.WriteLine($"Encerrando aplicação. Tchau! [{nome}]");
            break; 
        default:
            Console.WriteLine("Opção não disponivel no momento");
            break;
    }

    if (opcao != 4)
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}
while (opcao != 4);





