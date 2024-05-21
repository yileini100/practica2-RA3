using capaEntidad.Huesped;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad.Empleado;

namespace capaDatos.Empleaado
{
    public class Dempleado
    {
        public DataTable Listar_empleado(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_empleados", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                con.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                con = null;
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public string Guardar_empleado(int opcion, Eempleado ca)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_guardar_empleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                cmd.Parameters.Add("@id_empleado", SqlDbType.Int).Value = ca.id_empleado;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = ca.nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = ca.apellido;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = ca.email;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = ca.telefono;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = ca.direccion;
                cmd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = ca.cargo;
                cmd.Parameters.Add("@departamento", SqlDbType.VarChar).Value = ca.departamento;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = ca.id_usuario;
                con.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ejecutó el proceso.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return respuesta;
        }

        public string Estado_empleado(int id_empleado)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_estado_empleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_empleado", SqlDbType.Int).Value = id_empleado;
                con.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ejecutó el proceso.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return respuesta;
        }
    }
    
}
