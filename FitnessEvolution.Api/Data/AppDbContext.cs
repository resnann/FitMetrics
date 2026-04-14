using FitnessEvolution.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessEvolution.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public DbSet<Exercicio> Exercicios => Set<Exercicio>();

    public DbSet<Treino> Treinos => Set<Treino>();

    public DbSet<TreinoExercicio> TreinosExercicios => Set<TreinoExercicio>();

    public DbSet<RegistroTreino> RegistrosTreino => Set<RegistroTreino>();

    public DbSet<RegistroExercicio> RegistrosExercicios => Set<RegistroExercicio>();

    public DbSet<EvolucaoFisica> EvolucoesFisicas => Set<EvolucaoFisica>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(usuario => usuario.Email).IsUnique();
            entity.Property(usuario => usuario.AlturaCm).HasPrecision(5, 2);
            entity.Property(usuario => usuario.PesoAtualKg).HasPrecision(5, 2);
        });

        modelBuilder.Entity<TreinoExercicio>(entity =>
        {
            entity.Property(treinoExercicio => treinoExercicio.CargaSugeridaKg).HasPrecision(6, 2);

            entity.HasOne(treinoExercicio => treinoExercicio.Treino)
                .WithMany(treino => treino.TreinosExercicios)
                .HasForeignKey(treinoExercicio => treinoExercicio.TreinoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(treinoExercicio => treinoExercicio.Exercicio)
                .WithMany(exercicio => exercicio.TreinosExercicios)
                .HasForeignKey(treinoExercicio => treinoExercicio.ExercicioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Treino>(entity =>
        {
            entity.HasOne(treino => treino.Usuario)
                .WithMany(usuario => usuario.Treinos)
                .HasForeignKey(treino => treino.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RegistroTreino>(entity =>
        {
            entity.HasOne(registroTreino => registroTreino.Usuario)
                .WithMany(usuario => usuario.RegistrosTreino)
                .HasForeignKey(registroTreino => registroTreino.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(registroTreino => registroTreino.Treino)
                .WithMany(treino => treino.RegistrosTreino)
                .HasForeignKey(registroTreino => registroTreino.TreinoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<RegistroExercicio>(entity =>
        {
            entity.Property(registroExercicio => registroExercicio.CargaUtilizadaKg).HasPrecision(6, 2);

            entity.HasOne(registroExercicio => registroExercicio.RegistroTreino)
                .WithMany(registroTreino => registroTreino.RegistrosExercicios)
                .HasForeignKey(registroExercicio => registroExercicio.RegistroTreinoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(registroExercicio => registroExercicio.Exercicio)
                .WithMany(exercicio => exercicio.RegistrosExercicios)
                .HasForeignKey(registroExercicio => registroExercicio.ExercicioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<EvolucaoFisica>(entity =>
        {
            entity.Property(evolucaoFisica => evolucaoFisica.PesoKg).HasPrecision(5, 2);
            entity.Property(evolucaoFisica => evolucaoFisica.PercentualGordura).HasPrecision(5, 2);
            entity.Property(evolucaoFisica => evolucaoFisica.MassaMuscularKg).HasPrecision(5, 2);
            entity.Property(evolucaoFisica => evolucaoFisica.CinturaCm).HasPrecision(5, 2);
            entity.Property(evolucaoFisica => evolucaoFisica.QuadrilCm).HasPrecision(5, 2);

            entity.HasOne(evolucaoFisica => evolucaoFisica.Usuario)
                .WithMany(usuario => usuario.EvolucoesFisicas)
                .HasForeignKey(evolucaoFisica => evolucaoFisica.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
