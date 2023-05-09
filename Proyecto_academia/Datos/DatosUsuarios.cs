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
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
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
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                        });

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

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Correo", ousuarios.Correo);
                    cmd.Parameters.AddWithValue("NombreUsuario", ousuarios.Nombre_User);
                    cmd.Parameters.AddWithValue("Contra", ousuarios.Contra);
                    cmd.Parameters.AddWithValue("FechaCreacion", ousuarios.FechaCreacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }

        public bool Editar(Usuarios ousuarios)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", ousuarios.IdUsuario);
                    cmd.Parameters.AddWithValue("Correo", ousuarios.Correo);
                    cmd.Parameters.AddWithValue("NombreUsuario", ousuarios.Nombre_User);
                    cmd.Parameters.AddWithValue("Contra", ousuarios.Contra);
                    cmd.Parameters.AddWithValue("FechaCreacion", ousuarios.FechaCreacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int IdUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

    }
   
}

