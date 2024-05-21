using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad.Reserva
{
    public class Ereserva
    {
        public int id_reserva { get; set; }
        public int id_huesped { get; set; }
        public int id_empleado { get; set; }
        public DateTime fecha_llegada { get; set; }
        public DateTime fecha_salida { get; set; }
        public decimal precio_total { get; set; }
        public string metodo_pago { get; set; }
        public int cantidad_habitacion { get; set; } 
        public int cantidad_adultos { get; set; }
        public int cantidad_niños { get; set; } 
        public DateTime fecha_reserva { get; set; }
        public int id_usuario { get; set; }
    }
}
