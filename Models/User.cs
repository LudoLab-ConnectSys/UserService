using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    [Table("Usuario")]
    public class User
    {
        [Key] [Column("id_usuario")] public int IdUsuario { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("cedula_usuario")]
        public string CedulaUsuario { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("HashContrasena")]
        public string HashContrasena { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("apellidos_usuario")]
        public string ApellidosUsuario { get; set; }

        [Column("edad_usuario")] public int? EdadUsuario { get; set; }

        [MaxLength(100)]
        [Column("correo_usuario")]
        public string CorreoUsuario { get; set; }

        [MaxLength(20)]
        [Column("celular_usuario")]
        public string? CelularUsuario { get; set; }

        [MaxLength(20)]
        [Column("telefono_usuario")]
        public string? TelefonoUsuario { get; set; }

        [Column("FechaNacimiento")] public DateTime? FechaNacimiento { get; set; }

        [Column("definicionEtnica")] public int? DefinicionEtnica { get; set; }

        [MaxLength(50)] [Column("genero")] public string? Genero { get; set; }

        [Column("tieneDiscapacidad")] public bool? TieneDiscapacidad { get; set; }

        [MaxLength(50)]
        [Column("numeroCarnetConadis")]
        public string? NumeroCarnetConadis { get; set; }

        [Column("FechaCreacion")] public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Column("UltimoLogin")] public DateTime? UltimoLogin { get; set; }

        [Required] [Column("estadoActivo")] public bool EstadoActivo { get; set; }
    }
}