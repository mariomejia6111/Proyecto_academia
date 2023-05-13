using System;
using System.ComponentModel.DataAnnotations;
namespace Entidades {
    public class Credencial {
        [Required(ErrorMessage = "Se necesita un correo electrónico")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Hace falta una contraseña")]
        public string? Contra { get; set; }
    }
}