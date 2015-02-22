using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class OrdenesController : Controller
    {
        private InformacionDbContext informacion = new InformacionDbContext();
        private EstadoDbContext estado = new EstadoDbContext();
        // GET: Ordenes
        public ActionResult Index()
        {
            List<String> list_lunes = new List<String>();

        DateTime fechaActual = DateTime.Now;
            DateTime fechaMinima = DateTime.MinValue;
            fechaMinima = fechaActual.AddDays(1 - Convert.ToDouble(fechaActual.DayOfWeek));
            DateTime fechadesdesemana = fechaMinima.Date;
            string fecha_Lunes = fechadesdesemana.Year + "/" + fechadesdesemana.Month  +  "/" + fechadesdesemana.Day;
            string fecha_Martes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(1).Day;
            string fecha_Miercoles = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(2).Day;
            string fecha_Jueves = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(3).Day;
            string fecha_Viernes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(4).Day;

             var Lunes =  informacion.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Viernes + "'").ToList() ;
            
            for (var i = 0; i < Lunes.Count; i++)
            {
                
                var result = estado.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Lunes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                list_lunes.Add(Convert.ToString(result[0].num_orden));

        }
            ViewBag.Lunes = list_lunes;
           

            return View();
        }
    }
}