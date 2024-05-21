using capaEntidad.Habitacion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos.Habitacion
{
    public class Dhabitacion
    {
        public DataTable Listar_habitacion(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_habitacion", con);
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

        public string Guardar_habitacion(int opcion, Ehabitacion ca)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_guardar_habitacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                cmd.Parameters.Add("@id_habitacion", SqlDbType.Int).Value = ca.id_habitacion;
                cmd.Parameters.Add("@id_tipoHabitacion", SqlDbType.Int).Value = ca.id_TipoHabitacion;
                cmd.Parameters.Add("@capacidad", SqlDbType.Int).Value = ca.capacidad;
                cmd.Parameters.Add("@numero_habitacion", SqlDbType.Int).Value = ca.numero_habitación;
                cmd.Parameters.Add("@precio_por_noche", SqlDbType.Decimal).Value = ca.precio_por_noche;
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

        public string Estado_habitacion(int id_habitacion)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_estado_habitacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_habitacion", SqlDbType.Int).Value = id_habitacion;
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

        public DataTable Listar_usuario()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable Listar_tipoH()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_id_tipoH", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}
