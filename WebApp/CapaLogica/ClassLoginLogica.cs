using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.CapaDatos;

namespace WebApp.CapaLogica
{
    public class ClassLoginLogica
    {
        public Usuario ValidarLogin(string correo, string contraseña)
        {
            Usuario usuarioEntidad = null;
            using (SqlConnection conn = new SqlConnection(DBconn.conn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correo));
                        cmd.Parameters.Add(new SqlParameter("@Contraseña", contraseña));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                usuarioEntidad = new Usuario
                                {
                                    IDUsuario = rdr.GetInt32(rdr.GetOrdinal("IDUsuario")),
                                    CorreoElectronico = rdr.GetString(rdr.GetOrdinal("CorreoElectronico")),
                                    Rol = rdr.GetString(rdr.GetOrdinal("Rol"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al validar el login", ex);
                }
            }
            return usuarioEntidad;
        }
    }
}