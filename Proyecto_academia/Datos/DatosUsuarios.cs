using Proyecto_academia.Models;
using System.Data.SqlClient;
using System.Data;
namespace Proyecto_academia.Datos
{
    public class DatosUsuarios
    {


        public List<Usuarios> Listar()
        {
           var oLista = new List<Usuarios>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from Usuarios;",conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Usuarios()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Correo = dr["Correo"].ToString(),
                            Nombre_User = dr["NombreUsuario"].ToString(),
                            Contra = dr["Contra"].ToString(),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]),

                        }) ;
                    }
                }
            }
            return oLista;
        }

        public bool Guardar(Usuarios ousuarios)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();
                using (var conexion = new SqlConnection())
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("", conexion);
                }


            }catch (Exception e)
            {

            }

            return rpta;
        }
       
       
    }
   
}

