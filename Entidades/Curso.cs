using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Entidades {
    public class Curso {
        [Required (ErrorMessage = "Establezca una clave para este curso")]
        public int IdCurso { get; set; }
        [Required (ErrorMessage = "Ingrese el nombre del curso")]
        public string? NombreCurso { get; set; }
        public string? DescripcionCurso { get; set; }
        [Required (ErrorMessage = "Introduzca la duración del curso")]
        public int? DuracionCurso { get; set; }
        [Required]
        public string? DescripcionDuracion { get; set; }
        [Required]
        public string? NivelCurso { get; set; }
        [Required]
        public string? RequisitosPrevios { get; set; }
        [Required (ErrorMessage = "Ingrese el precio del curso")]
        public decimal? Precio { get; set; }
    }
}