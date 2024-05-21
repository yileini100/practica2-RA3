using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad.Empleado
{
    public class Eempleado
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public double telefono { get; set; }
        public string direccion { get; set; }
        public string cargo { get; set; }
        public string departamento { get; set; }
        public int id_usuario { get; set; }
    }
}
