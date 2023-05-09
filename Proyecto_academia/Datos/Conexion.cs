using System.Data.SqlClient;

namespace Proyecto_academia.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:conexion").Value;

        }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}
