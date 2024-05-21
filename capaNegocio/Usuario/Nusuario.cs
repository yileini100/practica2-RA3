using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos.Usuario;
using capaEntidad.Usuario;

namespace capaNegocio.Usuario
{
    public class Nusuario
    {
        Dusuario objd = new Dusuario();

        public DataTable N_users(Eusuario obje)
        {
            return objd.D_user(obje);
        }
    }
}
