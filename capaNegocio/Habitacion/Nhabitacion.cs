using capaDatos.Habitacion;
using capaEntidad.Habitacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio.Habitacion
{
    public class Nhabitacion
    {
        public static DataTable Listar_habitacion(string valor)
        {
            Dhabitacion datos = new Dhabitacion();
            return datos.Listar_habitacion(valor);
        }
        public static string Guardar_habitacion(int opcion, Ehabitacion ca)
        {
            Dhabitacion datos = new Dhabitacion();
            return datos.Guardar_habitacion(opcion, ca);
        }

        public static string Estado_habitacion(int id_empleado)
        {
            Dhabitacion datos = new Dhabitacion();
            return datos.Estado_habitacion(id_empleado);
        }
    }
}
