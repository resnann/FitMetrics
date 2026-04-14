using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.Models;

public class EvolucaoFisica
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    public decimal PesoKg { get; set; }

    public decimal? PercentualGordura { get; set; }

    public decimal? MassaMuscularKg { get; set; }

    public decimal? CinturaCm { get; set; }

    public decimal? QuadrilCm { get; set; }

    [MaxLength(500)]
    public string? Observacoes { get; set; }

    public Usuario? Usuario { get; set; }
}
