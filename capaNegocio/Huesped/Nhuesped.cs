using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaDatos.Empleaado;
using capaDatos.Huesped;
using capaEntidad;
using capaEntidad.Huesped;

namespace capaNegocio.Huesped
{
    public class Nhuesped
    {
        public static DataTable Listar_huesped(string valor)
        {
            Dhuesped datos = new Dhuesped();
            return datos.Listar_huesped(valor);
        }
        public static string Guardar_huesped(int opcion, Ehuesped ca)
        {
            Dhuesped datos = new Dhuesped();
            return datos.Guardar_huesped(opcion, ca);
        }
        public static DataTable Listar_usuario()
        {
            Dhuesped datos = new Dhuesped();
            return datos.Listar_usuario();
        }
        public static string Estado_huesped(int id_huesped)
        {
            Dhuesped datos = new Dhuesped();
            return datos.Estado_huesped(id_huesped);
        }
    }

   
}
