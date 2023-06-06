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
    public class DatosCursos : IEscritura<Curso>, ILectura<Curso>
    {
        public bool Editar(Curso curso)
        {
            bool a;
            try
            {
                var cn = new Conexion();
                using (var conn = new SqlConnection(cn.getCadenaSQL()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_EditarCurso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", curso.IdCurso);
                    cmd.Parameters.AddWithValue("@b", curso.NombreCurso);
                    cmd.Parameters.AddWithValue("@c", curso.DescripcionCurso);
                    cmd.Parameters.AddWithValue("@d", curso.DuracionCurso);
                    cmd.Parameters.AddWithValue("@e", curso.DescripcionDuracion);
                    cmd.Parameters.AddWithValue("@f", curso.NivelCurso);
                    cmd.Parameters.AddWithValue("@g", curso.RequisitosPrevios);
                    cmd.Parameters.AddWithValue("@h", curso.Precio);
                    cmd.ExecuteNonQuery();
                }
                a = true;
            }
            catch (Exception e) { a = false; }
            return a;
        }
        public bool Eliminar(int id)
        {
            bool a;
            try
            {
                var cn = new Conexion();

                using (var conn = new SqlConnection(cn.getCadenaSQL()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_EliminarCurso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", id);
                    cmd.ExecuteNonQuery();
                }
                a = true;
            }
            catch (Exception e) { a = false; }
            return a;
        }
        public bool Guardar(Curso curso)
        {
            bool a;
            try
            {
                var cn = new Conexion();
                using (var conn = new SqlConnection(cn.getCadenaSQL()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_GuardarCurso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", curso.IdCurso);
                    cmd.Parameters.AddWithValue("@b", curso.NombreCurso);
                    cmd.Parameters.AddWithValue("@c", curso.DescripcionCurso);
                    cmd.Parameters.AddWithValue("@d", curso.DuracionCurso);
                    cmd.Parameters.AddWithValue("@e", curso.DescripcionDuracion);
                    cmd.Parameters.AddWithValue("@f", curso.NivelCurso);
                    cmd.Parameters.AddWithValue("@g", curso.RequisitosPrevios);
                    cmd.Parameters.AddWithValue("@h", curso.Precio);
                    cmd.ExecuteNonQuery();
                }
                a = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                a = false;
            }

            return a;
        }
        public List<Curso> Listar()
        {
            var cursos = new List<Curso>();
            var cn = new Conexion();
            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_ListarCursos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cursos.Add(new Curso()
                        {
                            IdCurso = dr.GetInt32(0),
                            NombreCurso = dr.GetString(1),
                            DescripcionCurso = dr.GetString(2),
                            DuracionCurso = dr.GetInt32(3),
                            DescripcionDuracion = dr.GetString(4),
                            NivelCurso = dr.GetString(5),
                            RequisitosPrevios = dr.GetString(6),
                            Precio = dr.GetDecimal(7)
                        });

                    }
                }
            }
            return cursos;
        }
        public Curso Obtener(int id)
        {
            var curso = new Curso();
            var cn = new Conexion();
            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerCurso", conn);
                cmd.Parameters.AddWithValue("@a", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        curso.IdCurso = dr.GetInt32(0);
                        curso.NombreCurso = dr.GetString(1);
                        curso.DescripcionCurso = dr.GetString(2);
                        curso.DuracionCurso = dr.GetInt32(3);
                        curso.DescripcionCurso = dr.GetString(4);
                        curso.NivelCurso = dr.GetString(5);
                        curso.RequisitosPrevios = dr.GetString(6);
                        curso.Precio = dr.GetDecimal(7);
                       
                    }
                }
                return curso;
            }
        }
        public List<Curso> CursosDocentes(string a)
        {
            List<Curso> cursos = new List<Curso>(); 
            var cn = new Conexion();
            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_CursosDocentes", conn);
                cmd.Parameters.AddWithValue("@a", a);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cursos.Add(new Curso()
                        {
                            NombreCurso = dr.GetString(0),
                            DescripcionCurso = dr.GetString(1),
                            DuracionCurso = dr.GetInt32(2),
                            DescripcionDuracion = dr.GetString(3),
                            NivelCurso = dr.GetString(4),
                            RequisitosPrevios = dr.GetString(5)
                        });
                    }
                }
            }
            return cursos;
        }
        public Dictionary<int, string> DocentesCursos(string sp) {
            var datos = new Dictionary<int, string>();
            var cn = new Conexion();
            using (var conn = new SqlConnection(cn.getCadenaSQL())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SP_{sp}", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var r = cmd.ExecuteReader()) {
                    while (r.Read()) {
                        datos.Add(r.GetInt32(0), r.GetString(1));
                    }
                }
            }
            return datos;
        }
        public bool RelacionarCurso(int a, int b) {
            bool r;
            try {
                var cn = new Conexion();
                using (var conn = new SqlConnection(cn.getCadenaSQL())) {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_RelacionarCurso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", a);
                    cmd.Parameters.AddWithValue("@b", b);
                    cmd.ExecuteNonQuery();
                }
                r = true;
            } catch {
                r = false;
            }
            return r;
        }
    }
}