using System;

namespace Aula_8;

// Note: Ele NÃO herda de Conta. Ele é uma classe solta.
// Mas ele assina o contrato ITributavel.
public class SeguroDeVida : ITributavel
{
    public decimal CalcularImposto()
    {
        return 50.00m; // Taxa fixa de 50 reais
    }
}