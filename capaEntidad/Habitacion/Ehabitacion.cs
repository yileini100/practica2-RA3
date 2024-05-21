using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad.Habitacion
{
    public class Ehabitacion
    {
        public int id_habitacion { get; set; }
        public int id_TipoHabitacion { get; set; }
        public int capacidad { get; set; }
        public int numero_habitación { get; set; }
        public double precio_por_noche { get; set; }
        public int id_usuario { get; set; }
    }
}
