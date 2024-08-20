using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(idUsuario);
            if (usuario == null)
            {
                return NotFound(new { Message = "Usuario no encontrado." });
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario nuevoUsuario)
        {
            var usuarioCreado = await _usuarioService.CrearUsuarioAsync(nuevoUsuario);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { idUsuario = usuarioCreado.IdUsuario },
                usuarioCreado);
        }

        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> ActualizarUsuario(int idUsuario, [FromBody] Usuario usuarioActualizado)
        {
            if (idUsuario != usuarioActualizado.IdUsuario)
            {
                return BadRequest(new { Message = "El ID del usuario no coincide." });
            }

            try
            {
                await _usuarioService.ActualizarUsuarioAsync(usuarioActualizado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> EliminarUsuario(int idUsuario)
        {
            try
            {
                await _usuarioService.EliminarUsuarioAsync(idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        
        // Nuevo endpoint para listar usuarios sin último login
        [HttpGet("sinUltimoLogin")]
        public async Task<IActionResult> ObtenerUsuariosSinUltimoLogin()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosSinUltimoLoginAsync();
            return Ok(usuarios);
        }
        
        [HttpGet("sinContrasena")]
        public async Task<IActionResult> ObtenerUsuariosSinContrasena()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosSinContrasenaAsync();
            return Ok(usuarios);
        }

    }
}