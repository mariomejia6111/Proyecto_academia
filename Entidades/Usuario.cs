using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El Campo Correo Esta Vacio")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Campo Nombre De Usuario Esta Vacio")]
        public string? Nombre_User { get; set; }
        [Required(ErrorMessage = "El Campo Contaseña Esta Vacio")]
        public string? Contra { get; set; }
        public DateTime? FechaCreacion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un rol")]
        public int? IdRol { get; set; }

         public Rol? Rol { get; set; }
    }
}
