using FitnessEvolution.Api.Data;
using FitnessEvolution.Api.Interfaces.Repositories;
using FitnessEvolution.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessEvolution.Api.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public async Task<IEnumerable<Usuario>> ObterTodosAsync()
    {
        return await context.Usuarios
            .AsNoTracking()
            .OrderBy(usuario => usuario.Nome)
            .ToListAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(usuario => usuario.Email == email);
    }

    public async Task<Usuario> AdicionarAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }

    public async Task AtualizarAsync(Usuario usuario)
    {
        context.Usuarios.Update(usuario);
        await context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Usuario usuario)
    {
        context.Usuarios.Remove(usuario);
        await context.SaveChangesAsync();
    }
}
