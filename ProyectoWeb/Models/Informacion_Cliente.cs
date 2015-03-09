using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Informacion_Cliente
    {
        public int id { get; set; }
        public int num_orden { get; set; }
        public string cliente { get; set; }
        public string usuario { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public string nombre_trabajo { get; set; }
    }
}