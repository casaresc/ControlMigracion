using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApp.CapaDatos
{
    public static class DBconn
    {
        public static string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
    }
}