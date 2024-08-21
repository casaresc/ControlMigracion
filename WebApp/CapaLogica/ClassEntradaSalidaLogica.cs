using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.CapaDatos;

namespace WebApp.CapaLogica
{
    public class ClassEntradaSalidaLogica
    {
        public int RegistrarEntrada(Entrada entrada)
        {
            using (SqlConnection conn = new SqlConnection(DBconn.conn))
            {
                SqlCommand cmd = new SqlCommand("RegistrarEntrada", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDViajero", entrada.IDViajero);
                cmd.Parameters.AddWithValue("@FechaEntrada", entrada.FechaEntrada);
                cmd.Parameters.AddWithValue("@IDPaisOrigen", entrada.IDPaisOrigen);
                cmd.Parameters.AddWithValue("@IDUsuarioRegistro", entrada.IDUsuarioRegistro);
                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar la entrada", ex);
                }
            }
        }

        public int RegistrarSalida(Salida salida)
        {
            using (SqlConnection conn = new SqlConnection(DBconn.conn))
            {
                SqlCommand cmd = new SqlCommand("RegistrarSalida", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDViajero", salida.IDViajero);
                cmd.Parameters.AddWithValue("@FechaSalida", salida.FechaSalida);
                cmd.Parameters.AddWithValue("@IDPaisDestino", salida.IDPaisDestino);
                cmd.Parameters.AddWithValue("@IDUsuarioRegistro", salida.IDUsuarioRegistro);
                try
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar la salida", ex);
                }
            }
        }
    }
}