using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.Models;

public class RegistroExercicio
{
    public int Id { get; set; }

    public int RegistroTreinoId { get; set; }

    public int ExercicioId { get; set; }

    public int SeriesRealizadas { get; set; }

    public int RepeticoesRealizadas { get; set; }

    public decimal? CargaUtilizadaKg { get; set; }

    [MaxLength(300)]
    public string? Observacoes { get; set; }

    public RegistroTreino? RegistroTreino { get; set; }

    public Exercicio? Exercicio { get; set; }
}
