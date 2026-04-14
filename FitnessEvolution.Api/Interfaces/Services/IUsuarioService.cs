using FitnessEvolution.Api.DTOs;

namespace FitnessEvolution.Api.Interfaces.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioReadDto>> ObterTodosAsync();

    Task<UsuarioReadDto?> ObterPorIdAsync(int id);

    Task<UsuarioReadDto> CriarAsync(UsuarioCreateDto usuarioDto);

    Task<bool> AtualizarAsync(int id, UsuarioUpdateDto usuarioDto);

    Task<bool> RemoverAsync(int id);
}
