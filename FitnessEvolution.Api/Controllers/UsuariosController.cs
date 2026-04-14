using FitnessEvolution.Api.DTOs;
using FitnessEvolution.Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessEvolution.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController(IUsuarioService usuarioService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> ObterTodos()
    {
        var usuarios = await usuarioService.ObterTodosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UsuarioReadDto>> ObterPorId(int id)
    {
        var usuario = await usuarioService.ObterPorIdAsync(id);

        if (usuario is null)
        {
            return NotFound();
        }

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioReadDto>> Criar(UsuarioCreateDto usuarioDto)
    {
        var usuario = await usuarioService.CriarAsync(usuarioDto);
        return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, UsuarioUpdateDto usuarioDto)
    {
        var atualizado = await usuarioService.AtualizarAsync(id, usuarioDto);

        if (!atualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var removido = await usuarioService.RemoverAsync(id);

        if (!removido)
        {
            return NotFound();
        }

        return NoContent();
    }
}
