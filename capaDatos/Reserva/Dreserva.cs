using capaEntidad.Reserva;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos.Reserva
{
    public class Dreserva
    {
        public DataTable Listar_reserva(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_reserva", con);
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

        public string Guardar_reserva(int opcion, Ereserva ca)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_guardar_reserva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                cmd.Parameters.Add("@id_reserva", SqlDbType.Int).Value = ca.id_reserva;
                cmd.Parameters.Add("@id_huesped", SqlDbType.Int).Value = ca.id_huesped;
                cmd.Parameters.Add("@id_empleado", SqlDbType.Int).Value = ca.id_empleado;
                cmd.Parameters.Add("@fecha_llegada", SqlDbType.Date).Value = ca.fecha_llegada;
                cmd.Parameters.Add("@fecha_salida", SqlDbType.Date).Value = ca.fecha_salida;
                cmd.Parameters.Add("@precio_total", SqlDbType.Decimal).Value = ca.precio_total;
                cmd.Parameters.Add("@metodo_pago", SqlDbType.VarChar).Value = ca.metodo_pago;
                cmd.Parameters.Add("@cantidad_habitacion", SqlDbType.Int).Value = ca.cantidad_habitacion;
                cmd.Parameters.Add("@cantidad_adultos", SqlDbType.Int).Value = ca.cantidad_adultos;
                cmd.Parameters.Add("@cantidad_niños", SqlDbType.Int).Value = ca.cantidad_niños;
                cmd.Parameters.Add("@fecha_reserva", SqlDbType.Date).Value = ca.fecha_reserva;
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

        public DataTable Listar_emple()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_emple", con);
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

        public DataTable Listar_huesp()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_huesp", con);
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

        public string Estado_reserva(int id_reserva)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_estado_reserva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_reserva", SqlDbType.Int).Value = id_reserva;
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

    

