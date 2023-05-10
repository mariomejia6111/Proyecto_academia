using System.ComponentModel.DataAnnotations;
namespace Proyecto_academia.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }

        [Required (ErrorMessage ="El Campo Correo Esta Vacio")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Campo Nombre De Usuario Esta Vacio")]
        public string? Nombre_User { get; set; }
        [Required(ErrorMessage = "El Campo Contaseña Esta Vacio")]
        public string? Contra { get; set; }
        [Required(ErrorMessage = "El Campo Fecha De Creacion Esta Vacio")]
        public DateTime? FechaCreacion { get; set; }  
        

    }
}
