namespace FitnessEvolution.Api.Models;

public class TreinoExercicio
{
    public int Id { get; set; }

    public int TreinoId { get; set; }

    public int ExercicioId { get; set; }

    public int Ordem { get; set; }

    public int Series { get; set; }

    public int Repeticoes { get; set; }

    public decimal? CargaSugeridaKg { get; set; }

    public Treino? Treino { get; set; }

    public Exercicio? Exercicio { get; set; }
}
