using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.CapaDatos
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}