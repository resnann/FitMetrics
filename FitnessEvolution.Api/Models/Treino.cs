using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.Models;

public class Treino
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    [MaxLength(120)]
    public required string Nome { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public Usuario? Usuario { get; set; }

    public ICollection<TreinoExercicio> TreinosExercicios { get; set; } = [];

    public ICollection<RegistroTreino> RegistrosTreino { get; set; } = [];
}
