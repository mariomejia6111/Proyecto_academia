using Microsoft.AspNetCore.Mvc;
using Entidades;
using Logica;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Proyecto_academia.Controllers
{
    public class MantenedorController1 : Controller
    {
        
        public IActionResult Listar()
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null)
                return RedirectToAction("Login");

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
        // Inicio de Sesión
        public IActionResult Login() {
            return View();
        }



        [HttpPost]
        public IActionResult Login(Credencial c) {
            Autenticacion r;
            r = LogicaUsuarios.VerificarLogin(c);
            if (r.Estado) {
                HttpContext.Session.SetString("user", r.Usuario ?? "");
                HttpContext.Session.SetString("rol", r.IdRol.ToString() ?? "");

                String rol = r.IdRol.ToString() ?? "";

                if (rol == "1")
                    return RedirectToAction("Administrador");
                else if (rol == "2")
                    return RedirectToAction("Docente");
                else if (rol == "3")
                    return RedirectToAction("Alumno");

                return RedirectToAction("Error");
                //return RedirectToAction("Listar");
            } else {
                ModelState.AddModelError("", "Correo o contraseñea invalido");
                return View();
            }
        }

        // 1
        public IActionResult Administrador()
        {
            return View();
        }

        // 2
        public IActionResult Docente()
        {
            return View();
        }

        // 3
        public IActionResult Alumno()
        {
            return View();
        }

        public IActionResult Error() {
            return View();
        }
        // Fin -- Inicio de Sesión

        //inicio -- cerrar sesion

      public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("rol");
            return RedirectToAction("Login");
        }

        public IActionResult CambiarContra()
        {
            return View();
        }
        //fin--cerrar sesion


        

        //[HttpPost]
        //public IActionResult CambiarContra(Usuario usuario)
        //{

        //    LogicaUsuarios.CambiarContra(usuario.IdUsuario, usuario.Correo, usuario.Contra);
           
        //        return RedirectToAction("Login");
            
        //}

    }
}
