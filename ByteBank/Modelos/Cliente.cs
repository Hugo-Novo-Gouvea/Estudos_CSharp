namespace ByteBank.Modelos;

public class Cliente(string nome, string cpf, string senha)
{
    public string Nome { get; set; } = nome;
    public string Cpf { get; set; } = cpf;
    public string Senha { get; set; } = senha;
}