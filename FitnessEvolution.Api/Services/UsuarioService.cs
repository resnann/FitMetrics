using FitnessEvolution.Api.DTOs;
using FitnessEvolution.Api.Interfaces.Repositories;
using FitnessEvolution.Api.Interfaces.Services;
using FitnessEvolution.Api.Models;

namespace FitnessEvolution.Api.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
{
    public async Task<IEnumerable<UsuarioReadDto>> ObterTodosAsync()
    {
        var usuarios = await usuarioRepository.ObterTodosAsync();
        return usuarios.Select(MapearParaReadDto);
    }

    public async Task<UsuarioReadDto?> ObterPorIdAsync(int id)
    {
        var usuario = await usuarioRepository.ObterPorIdAsync(id);
        return usuario is null ? null : MapearParaReadDto(usuario);
    }

    public async Task<UsuarioReadDto> CriarAsync(UsuarioCreateDto usuarioDto)
    {
        var usuario = new Usuario
        {
            Nome = usuarioDto.Nome.Trim(),
            Email = usuarioDto.Email.Trim().ToLowerInvariant(),
            DataNascimento = usuarioDto.DataNascimento,
            AlturaCm = usuarioDto.AlturaCm,
            PesoAtualKg = usuarioDto.PesoAtualKg
        };

        await usuarioRepository.AdicionarAsync(usuario);

        return MapearParaReadDto(usuario);
    }

    public async Task<bool> AtualizarAsync(int id, UsuarioUpdateDto usuarioDto)
    {
        var usuario = await usuarioRepository.ObterPorIdAsync(id);

        if (usuario is null)
        {
            return false;
        }

        usuario.Nome = usuarioDto.Nome.Trim();
        usuario.Email = usuarioDto.Email.Trim().ToLowerInvariant();
        usuario.DataNascimento = usuarioDto.DataNascimento;
        usuario.AlturaCm = usuarioDto.AlturaCm;
        usuario.PesoAtualKg = usuarioDto.PesoAtualKg;

        await usuarioRepository.AtualizarAsync(usuario);
        return true;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var usuario = await usuarioRepository.ObterPorIdAsync(id);

        if (usuario is null)
        {
            return false;
        }

        await usuarioRepository.RemoverAsync(usuario);
        return true;
    }

    private static UsuarioReadDto MapearParaReadDto(Usuario usuario)
    {
        return new UsuarioReadDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            DataNascimento = usuario.DataNascimento,
            AlturaCm = usuario.AlturaCm,
            PesoAtualKg = usuario.PesoAtualKg,
            DataCriacao = usuario.DataCriacao
        };
    }
}
