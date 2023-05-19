using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autenticacion
    {
        public String? Usuario { get; set; }

        public int? IdRol { get; set; }
        public bool Estado { get; set; } = false;
    }
}
