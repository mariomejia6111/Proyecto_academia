using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ILectura<T>
    {
        public List<T> Listar();

        public T Obtener(int id);

    }
}
