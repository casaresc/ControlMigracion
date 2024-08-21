using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.CapaDatos;

namespace WebApp.CapaLogica
{
    public class ClassRegMigracionLogica
    {
        public int RegistrarEntrada(Entrada entrada)
        {
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("RegistrarEntrada", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDViajero", entrada.IDViajero);
                    cmd.Parameters.AddWithValue("@FechaEntrada", entrada.FechaEntrada);
                    cmd.Parameters.AddWithValue("@IDPaisOrigen", entrada.IDPaisOrigen);
                    cmd.Parameters.AddWithValue("@IDUsuarioRegistro", entrada.IDUsuarioRegistro);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int RegistrarSalida(Salida salida)
        {
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("RegistrarSalida", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDViajero", salida.IDViajero);
                    cmd.Parameters.AddWithValue("@FechaSalida", salida.FechaSalida);
                    cmd.Parameters.AddWithValue("@IDPaisDestino", salida.IDPaisDestino);
                    cmd.Parameters.AddWithValue("@IDUsuarioRegistro", salida.IDUsuarioRegistro);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public List<Entrada> ConsultarEntradasViajero(int idViajero)
        {
            List<Entrada> entradas = new List<Entrada>();
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("ConsultarEntradasViajero", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDViajero", idViajero);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entradas.Add(new Entrada
                            {
                                IDEntrada = reader.GetInt32(0),
                                IDViajero = idViajero,
                                FechaEntrada = reader.GetDateTime(1),
                                IDPaisOrigen = reader.GetInt32(2),
                                IDUsuarioRegistro = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return entradas;
        }
        public List<Salida> ConsultarSalidasViajero(int idViajero)
        {
            List<Salida> salidas = new List<Salida>();
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("ConsultarSalidasViajero", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDViajero", idViajero);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salidas.Add(new Salida
                            {
                                IDSalida = reader.GetInt32(0),
                                IDViajero = idViajero,
                                FechaSalida = reader.GetDateTime(1),
                                IDPaisDestino = reader.GetInt32(2),
                                IDUsuarioRegistro = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return salidas;
        }
    }
}