namespace FitnessEvolution.Api.DTOs;

public class UsuarioReadDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateOnly DataNascimento { get; set; }

    public decimal AlturaCm { get; set; }

    public decimal PesoAtualKg { get; set; }

    public DateTime DataCriacao { get; set; }
}
