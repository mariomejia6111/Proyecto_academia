using Microsoft.AspNetCore.Mvc;
using Entidades;
using Logica;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
namespace Proyecto_academia.Controllers {
    public class CursoController : Controller {
        public IActionResult Cursos() {
            var cursos = LogicaCursos.Listar();
            return View(cursos);
        }
        public IActionResult Guardar() {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Curso curso) {
            if (!ModelState.IsValid)
                return View();
            var a = LogicaCursos.Guardar(curso);
            if (a) return RedirectToAction("Cursos");
            else return View();
        }
        public IActionResult Editar(int id) {
            var curso = LogicaCursos.Obtener(id);
            return View(curso);
        }
        [HttpPost]
        public IActionResult Editar(Curso curso) {
            if (!ModelState.IsValid) 
                return View();
            var _curso = LogicaCursos.Editar(curso);
            if (_curso) 
                return RedirectToAction("Cursos");
            else 
                return View();
        }
        public IActionResult Eliminar(int id) {
            var curso = LogicaCursos.Obtener(id);
            return View(curso);
        }
        [HttpPost]
        public IActionResult Eliminar(Curso curso) {
            var _curso = LogicaCursos.Eliminar(curso.IdCurso);
            if (_curso) 
                return RedirectToAction("Cursos");
            else 
                return View();
        }
    }
}