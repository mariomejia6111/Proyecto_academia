using Microsoft.AspNetCore.Mvc;
using Proyecto_academia.Datos;
using Proyecto_academia.Models;

namespace Proyecto_academia.Controllers
{
    public class MantenedorController1 : Controller
    {
        DatosUsuarios _UsuariosDatos = new DatosUsuarios();
        public IActionResult Listar()
        {
            //La vista mostrara una lista 
            var oLista = _UsuariosDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //metodo solo devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Usuarios ousuarios)
        {
            //recibe el objeto para guardarlo bd


            if (!ModelState.IsValid)
            return View();

            var respuesta = _UsuariosDatos.Guardar(ousuarios);
            if (respuesta)
                 return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdUsuario)
        {
            //metodo solo devuelve la vista
            var Ousuario = _UsuariosDatos.Obtener(IdUsuario);
            return View(Ousuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuarios ousuarios)
        {
            //metodo solo devuelve la vista
            if (!ModelState.IsValid)
                return View();

            var respuesta = _UsuariosDatos.Editar(ousuarios);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int IdUsuario)
        {
            //metodo solo devuelve la vista
            var Ousuario = _UsuariosDatos.Obtener(IdUsuario);
            return View(Ousuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuarios ousuario)
        {

            var respuesta = _UsuariosDatos.Eliminar(ousuario.IdUsuario);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
