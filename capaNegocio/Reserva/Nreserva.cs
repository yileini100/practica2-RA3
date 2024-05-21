using capaDatos.Reserva;
using capaEntidad.Reserva;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio.Reserva
{
    public class Nreserva
    {
        public static DataTable Listar_reserva(string valor)
        {
            Dreserva datos = new Dreserva();
            return datos.Listar_reserva(valor);
        }
        public static string Guardar_reserva(int opcion, Ereserva ca)
        {
            Dreserva datos = new Dreserva();
            return datos.Guardar_reserva(opcion, ca);
        }
        public static DataTable Listar_usuario()
        {
            Dreserva datos = new Dreserva();
            return datos.Listar_usuario();
        }
        public static string Estado_reserva(int id_reserva)
        {
            Dreserva datos = new Dreserva();
            return datos.Estado_reserva(id_reserva);
        }
    }
}
