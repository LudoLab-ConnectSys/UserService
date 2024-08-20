using UserService.Models;

namespace UserService.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosUsuariosAsync();
        Task<Usuario> ObtenerUsuarioPorIdAsync(int idUsuario);
        Task<Usuario> CrearUsuarioAsync(Usuario nuevoUsuario);
        Task ActualizarUsuarioAsync(Usuario usuarioActualizado);

        Task EliminarUsuarioAsync(int idUsuario);

        // Nuevo método
        Task<IEnumerable<Usuario>> ObtenerUsuariosSinUltimoLoginAsync();
        Task<IEnumerable<Usuario>> ObtenerUsuariosSinContrasenaAsync();

    }
}