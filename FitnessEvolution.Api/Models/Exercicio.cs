using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.Models;

public class Exercicio
{
    public int Id { get; set; }

    [MaxLength(120)]
    public required string Nome { get; set; }

    [MaxLength(80)]
    public string? GrupoMuscular { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }

    public ICollection<TreinoExercicio> TreinosExercicios { get; set; } = [];

    public ICollection<RegistroExercicio> RegistrosExercicios { get; set; } = [];
}
