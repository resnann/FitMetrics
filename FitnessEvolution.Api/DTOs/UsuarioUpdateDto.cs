using System.ComponentModel.DataAnnotations;

namespace FitnessEvolution.Api.DTOs;

public class UsuarioUpdateDto
{
    [Required]
    [MaxLength(120)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(180)]
    public string Email { get; set; } = string.Empty;

    public DateOnly DataNascimento { get; set; }

    [Range(1, 300)]
    public decimal AlturaCm { get; set; }

    [Range(1, 500)]
    public decimal PesoAtualKg { get; set; }
}
