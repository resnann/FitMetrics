using FitnessEvolution.Api.Models;

namespace FitnessEvolution.Api.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ObterTodosAsync();

    Task<Usuario?> ObterPorIdAsync(int id);

    Task<Usuario?> ObterPorEmailAsync(string email);

    Task<Usuario> AdicionarAsync(Usuario usuario);

    Task AtualizarAsync(Usuario usuario);

    Task RemoverAsync(Usuario usuario);
}
