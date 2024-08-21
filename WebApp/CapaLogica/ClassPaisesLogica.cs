using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.CapaDatos;

namespace WebApp.CapaLogica
{
    public class ClassPaisesLogica
    {
        public List<Pais> ListarPaises()
        {
            List<Pais> lista = new List<Pais>();
            using (SqlConnection conn = new SqlConnection(DBconn.conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Pais
                            {
                                IDPais = Convert.ToInt32(dr["IDPais"]),
                                NombrePais = dr["NombrePais"].ToString(),
                                CodigoISO = dr["CodigoISO"].ToString()
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los países", ex);
                }
            }
        }
    }
}