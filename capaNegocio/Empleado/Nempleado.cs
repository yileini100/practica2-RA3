using capaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Empleaado;
using capaEntidad.Empleado;
using capaEntidad;

namespace capaNegocio.Empleado
{
    public class Nempleado
    {
        public static DataTable Listar_empleado(string valor)
        {
            Dempleado datos = new Dempleado();
            return datos.Listar_empleado(valor);
        }
        public static string Guardar_empleado(int opcion, Eempleado ca)
        {
            Dempleado datos = new Dempleado();
            return datos.Guardar_empleado(opcion, ca);
        }

        public static string Estado_empleado(int id_empleado)
        {
            Dempleado datos= new Dempleado();
            return datos.Estado_empleado(id_empleado);
        }
    }
}
