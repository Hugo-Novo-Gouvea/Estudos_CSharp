public class Cliente
{
    // === PROPRIEDADES (O Jeito Moderno) ===
    // Note que agora usamos PascalCase (Primeira letra Maiúscula)
    
    public string Nome { get; set; }
    public string Cpf { get; set; }

    // O Pulo do Gato: 
    // Todo mundo vê (get público), mas só a classe mexe (set privado)
    public decimal Saldo { get; private set; }

    // === CONSTRUTOR ===
    public Cliente(string nome, string cpf)
    {
        // Como as propriedades são variáveis, atribuímos igualzinho
        this.Nome = nome;
        this.Cpf = cpf;
        this.Saldo = 0; // O set privado permite mexer AQUI DENTRO
    }

    // === MÉTODOS ===
    public void Depositar(decimal valor)
    {
        // O set privado permite mexer AQUI DENTRO
        this.Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if(valor <= this.Saldo)
        {
            this.Saldo -= valor;
        }
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Cliente: {Nome} | CPF: {Cpf} | Saldo: {Saldo:C}");
    }
}