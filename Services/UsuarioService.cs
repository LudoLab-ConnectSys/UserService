using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int idUsuario)
        {
            return await _context.Usuarios.FindAsync(idUsuario);
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario nuevoUsuario)
        {
            nuevoUsuario.FechaCreacion = DateTime.Now;
            nuevoUsuario.EstadoActivo = true;

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return nuevoUsuario;
        }

        public async Task ActualizarUsuarioAsync(Usuario usuarioActualizado)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(usuarioActualizado.IdUsuario);
            if (usuarioExistente == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            usuarioExistente.CedulaUsuario = usuarioActualizado.CedulaUsuario;
            usuarioExistente.NombreUsuario = usuarioActualizado.NombreUsuario;
            usuarioExistente.ApellidosUsuario = usuarioActualizado.ApellidosUsuario;
            usuarioExistente.EdadUsuario = usuarioActualizado.EdadUsuario;
            usuarioExistente.CorreoUsuario = usuarioActualizado.CorreoUsuario;
            usuarioExistente.CelularUsuario = usuarioActualizado.CelularUsuario;
            usuarioExistente.TelefonoUsuario = usuarioActualizado.TelefonoUsuario;
            usuarioExistente.FechaNacimiento = usuarioActualizado.FechaNacimiento;
            usuarioExistente.DefinicionEtnica = usuarioActualizado.DefinicionEtnica;
            usuarioExistente.Genero = usuarioActualizado.Genero;
            usuarioExistente.TieneDiscapacidad = usuarioActualizado.TieneDiscapacidad;
            usuarioExistente.NumeroCarnetConadis = usuarioActualizado.NumeroCarnetConadis;
            usuarioExistente.EstadoActivo = usuarioActualizado.EstadoActivo;

            _context.Usuarios.Update(usuarioExistente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarUsuarioAsync(int idUsuario)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        // Implementación del nuevo método
        public async Task<IEnumerable<Usuario>> ObtenerUsuariosSinUltimoLoginAsync()
        {
            return await _context.Usuarios
                .Where(u => u.UltimoLogin == null)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Usuario>> ObtenerUsuariosSinContrasenaAsync()
        {
            return await _context.Usuarios
                .Where(u => u.Contrasena == null)
                .ToListAsync();
        }

    }
}