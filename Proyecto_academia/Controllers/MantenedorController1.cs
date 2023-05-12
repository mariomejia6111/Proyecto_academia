using Microsoft.AspNetCore.Mvc;
using Entidades;
using Logica;

namespace Proyecto_academia.Controllers
{
    public class MantenedorController1 : Controller
    {
        
        public IActionResult Listar()
        {
            //La vista mostrara una lista 
            var oLista = LogicaUsuarios.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //metodo solo devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Usuario ousuarios)
        {
            //recibe el objeto para guardarlo bd


            if (!ModelState.IsValid)
            return View();

            var respuesta = LogicaUsuarios.Guardar(ousuarios);
            if (respuesta)
                 return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdUsuario)
        {
            //metodo solo devuelve la vista
            var Ousuario = LogicaUsuarios.Obtener(IdUsuario);
            return View(Ousuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario ousuarios)
        {
            //metodo solo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            var respuesta = LogicaUsuarios.Editar(ousuarios);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int IdUsuario)
        {
            //metodo solo devuelve la vista
            var Ousuario = LogicaUsuarios.Obtener(IdUsuario);
            return View(Ousuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario ousuario)
        {

            var respuesta = LogicaUsuarios.Eliminar(ousuario.IdUsuario);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
