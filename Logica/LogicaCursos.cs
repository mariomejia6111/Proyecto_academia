using Datos.Operaciones;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logica
{
    public class LogicaCursos
    {
        static DatosCursos _CursosDatos = new DatosCursos();
        public static List<Curso> Listar() => _CursosDatos.Listar();
        public static Curso Obtener(int id) => _CursosDatos.Obtener(id);
        public static bool Guardar(Curso curso) => _CursosDatos.Guardar(curso);
        public static bool Editar(Curso curso) => _CursosDatos.Editar(curso);
        public static bool Eliminar(int id) => _CursosDatos.Eliminar(id);
    }
}