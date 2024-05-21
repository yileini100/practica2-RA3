using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad.Usuario; 
using System.Configuration;

namespace capaDatos.Usuario
{
    public class Dusuario
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable D_usuario(Eusuario obje)
        {
            SqlCommand cmd = new SqlCommand("sp_login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuarios", obje.usuario);
            cmd.Parameters.AddWithValue("@contraseña", obje.contraseña);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
    }
}
