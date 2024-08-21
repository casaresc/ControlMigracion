using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.CapaDatos
{
    public class Entrada
    {
        public int IDEntrada { get; set; }
        public int IDViajero { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int IDPaisOrigen { get; set; }
        public int IDUsuarioRegistro { get; set; }
    }
}