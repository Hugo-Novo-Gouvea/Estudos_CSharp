string nomeDoAluno;
string nomeDoCurso;
int idade;
decimal preco;

// 1. Coletando Nome
Console.Write("Informe o nome do aluno: ");
nomeDoAluno = Console.ReadLine() ?? "";

// 2. Coletando Idade
Console.Write("Informe a idade do aluno: ");
while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0)
{
    Console.WriteLine("Valor Não permitido... Tente novamente");
    Console.Write("Informe a idade do aluno: ");
}

// 3. Coletando Curso
Console.Write("Informe o nome do curso: ");
nomeDoCurso = Console.ReadLine() ?? "";

// 4. Coletando Preço
Console.Write("Informe o preço do curso: ");
while(!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0)
{
    Console.WriteLine("Valor Não permitido... Tente novamente");
    Console.Write("Informe o preço do curso: ");
}

Console.Clear();

Console.WriteLine("=================================");
Console.WriteLine("       RELATÓRIO DE MATRÍCULA    ");
Console.WriteLine("=================================");
Console.WriteLine($"Aluno: {nomeDoAluno}");
Console.WriteLine($"Idade: {idade} anos");
Console.WriteLine($"Curso: {nomeDoCurso}");
Console.WriteLine($"Investimento: {preco:C}"); // O :C formata como dinheiro
Console.WriteLine("=================================");