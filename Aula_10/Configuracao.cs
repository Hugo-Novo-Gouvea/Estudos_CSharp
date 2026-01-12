namespace Aula_10;

public class Configuracao
{
    public string NomeJogador { get; set; }
    public int NivelDificuldade { get; set; } // 1 = Fácil, 5 = Hardcore
    public bool SomAtivado { get; set; }
    public DateTime UltimoAcesso { get; set; }
}