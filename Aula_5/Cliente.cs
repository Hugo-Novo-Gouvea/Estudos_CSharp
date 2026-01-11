public class Cliente
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public decimal Saldo { get; private set; }

    public Cliente(string nome, string cpf) //Construtor, sempre ter o mesmo nome da classe(objeto) e apenas se´e public na frente, sem tipo de variavel
    {
        this.Nome = nome;
        this.Cpf = cpf;
        this.Saldo = 0m;
    }

    public void Depositar(decimal valor)
    {
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
        Console.WriteLine($"Cliente {Nome} | CPF: {Cpf} | Saldo {Saldo:C}");
    }
}