using Datos.Operaciones;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaUsuarios
    {
        static DatosUsuarios _UsuariosDatos = new DatosUsuarios();

        public static List<Usuario> Listar() => _UsuariosDatos.Listar();

        public static Usuario Obtener(int id) => _UsuariosDatos.Obtener(id);
        
        public static bool Guardar(Usuario usuario) => _UsuariosDatos.Guardar(usuario);
           

        public static bool Editar(Usuario usuario) => _UsuariosDatos.Editar(usuario);

        public static bool Eliminar(int id) => _UsuariosDatos.Eliminar(id);
        public static bool VerificarLogin(Credencial c) => _UsuariosDatos.VerificarLogin(c);

        //public static bool  CambiarContra(Usuario IdUsuario, Usuario Correo, Usuario Contra ) => _UsuariosDatos.CambiarContra(IdUsuario,Correo,Contra);

    }
}
