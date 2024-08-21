using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.CapaDatos
{
    public class Salida
    {
        public int IDSalida { get; set; }
        public int IDViajero { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IDPaisDestino { get; set; }
        public int IDUsuarioRegistro { get; set; }
    }
}