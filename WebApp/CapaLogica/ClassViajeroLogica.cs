using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.CapaDatos;

namespace WebApp.CapaLogica
{
    public class ClassViajeroLogica
    {
        public List<Viajero> ListarViajeros()
        {
            List<Viajero> lista = new List<Viajero>();
            using (SqlConnection conn = new SqlConnection(DBconn.conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Viajeros", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Viajero
                            {
                                IDViajero = Convert.ToInt32(dr["IDViajero"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                NroPasaporte = dr["NroPasaporte"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                Nacionalidad = Convert.ToInt32(dr["Nacionalidad"])
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los viajeros", ex);
                }
            }
        }
        public int InsertarViajero(Viajero viajero)
        {
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@Nombre", viajero.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", viajero.Apellido);
                    cmd.Parameters.AddWithValue("@NroPasaporte", viajero.NroPasaporte);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", viajero.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Nacionalidad", viajero.Nacionalidad);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool ActualizarViajero(Viajero viajero)
        {
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@IDViajero", viajero.IDViajero);
                    cmd.Parameters.AddWithValue("@Nombre", viajero.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", viajero.Apellido);
                    cmd.Parameters.AddWithValue("@NroPasaporte", viajero.NroPasaporte);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", viajero.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Nacionalidad", viajero.Nacionalidad);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool EliminarViajero(int idViajero)
        {
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@IDViajero", idViajero);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public Viajero ObtenerViajero(int idViajero)
        {
            using (var conn = new SqlConnection(DBconn.conn))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@IDViajero", idViajero);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Viajero
                            {
                                IDViajero = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                NroPasaporte = reader.GetString(3),
                                FechaNacimiento = reader.GetDateTime(4),
                                Nacionalidad = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
