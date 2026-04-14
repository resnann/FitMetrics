using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.Models;

public class Usuario
{
    public int Id { get; set; }

    [MaxLength(120)]
    public required string Nome { get; set; }

    [MaxLength(180)]
    public required string Email { get; set; }

    public DateOnly DataNascimento { get; set; }

    public decimal AlturaCm { get; set; }

    public decimal PesoAtualKg { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public ICollection<Treino> Treinos { get; set; } = [];

    public ICollection<RegistroTreino> RegistrosTreino { get; set; } = [];

    public ICollection<EvolucaoFisica> EvolucoesFisicas { get; set; } = [];
}
