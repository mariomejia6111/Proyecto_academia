using Datos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Operaciones
{
    public class DatosUsuarios : IEscritura<Usuario>, ILectura<Usuario>
    {
        public bool Editar(Usuario entidad)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar1", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", entidad.IdUsuario);
                    cmd.Parameters.AddWithValue("Correo", entidad.Correo);
                    cmd.Parameters.AddWithValue("NombreUsuario", entidad.Nombre_User);
                    cmd.Parameters.AddWithValue("Contra", entidad.Contra);
                    cmd.Parameters.AddWithValue("FechaCreacion", entidad.FechaCreacion);
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

        public bool Eliminar(int id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", id);
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

        public bool Guardar(Usuario entidad)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar1", conexion);
                    cmd.Parameters.AddWithValue("Correo", entidad.Correo);
                    cmd.Parameters.AddWithValue("NombreUsuario", entidad.Nombre_User);
                    cmd.Parameters.AddWithValue("Contra", entidad.Contra);
                    cmd.Parameters.AddWithValue("FechaCreacion", entidad.FechaCreacion);
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

        public List<Usuario> Listar()
        {
            var oLista = new List<Usuario>();

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
                        oLista.Add(new Usuario()
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

        public Usuario Obtener(int id)
        {
            var ousuarios = new Usuario();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdUsuario", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ousuarios.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        ousuarios.Correo = dr["Correo"].ToString();
                        ousuarios.Nombre_User = dr["NombreUsuario"].ToString();
                        ousuarios.Contra = dr["Contra"].ToString();
                        ousuarios.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                    }
                }
                return ousuarios;
            }
        }
    }
}
