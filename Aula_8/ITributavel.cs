namespace Aula_8;

// Convenção: Interfaces sempre começam com "I" maiúsculo
public interface ITributavel
{
    // Quem assinar esse contrato TEM que saber calcular seu imposto
    decimal CalcularImposto();
}