using System.ComponentModel.DataAnnotations;

namespace proyectoImagemaker.API.Dtos
{
    public class UsuarioParaRegistrarDto
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Tu password debe ser entre 4 y 8 caracteres")]
        public string Password { get; set; }
    }
}