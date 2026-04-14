using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.Models;

public class RegistroTreino
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int TreinoId { get; set; }

    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    [MaxLength(500)]
    public string? Observacoes { get; set; }

    public Usuario? Usuario { get; set; }

    public Treino? Treino { get; set; }

    public ICollection<RegistroExercicio> RegistrosExercicios { get; set; } = [];
}
