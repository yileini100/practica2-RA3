 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad.Huesped;

namespace capaDatos.Huesped
{
    public class Dhuesped
    {
        public DataTable Listar_huesped(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_listar_huesped", con);
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

        public string Guardar_huesped(int opcion, Ehuesped ca)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_guardar_huesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                cmd.Parameters.Add("@id_huesped", SqlDbType.Int).Value = ca.id_huesped;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = ca.nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = ca.apellido;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = ca.email;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = ca.telefono;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = ca.direccion;
                cmd.Parameters.Add("@pais", SqlDbType.VarChar).Value = ca.pais;
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

        public string Estado_huesped(int id_huesped)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_estado_huesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_huesped", SqlDbType.Int).Value = id_huesped;
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
