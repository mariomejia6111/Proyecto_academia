using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IEscritura<T>
    {
        public bool Guardar(T entidad);

        public bool Editar(T entidad);

        public bool Eliminar(int id);
    }
}
