using System.ComponentModel.DataAnnotations;

namespace HomeRentApp.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [MinLength(6)]
        public string Contraseña { get; set; }

        [Required]
        public string TipoUsuario { get; set; } // "Arrendador" o "Arrendatario"
    }
}
