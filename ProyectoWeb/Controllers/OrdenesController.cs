using ProyectoWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class OrdenesController : Controller
    {
        private ImprentaContext db = new ImprentaContext();
        public Boolean session()
        {
            if (Request.Cookies["userName"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: Ordenes
        public ActionResult Index()
        {
            if (session())
            {
                List<Estado> list_lunes = new List<Estado>();
            List<Estado> list_martes = new List<Estado>();
            List<Estado> list_miercoles = new List<Estado>();
            List<Estado> list_jueves = new List<Estado>();
            List<Estado> list_viernes = new List<Estado>();
            

            DateTime fechaActual = DateTime.Now;
            DateTime fechaMinima = DateTime.MinValue;
            fechaMinima = fechaActual.AddDays(1 - Convert.ToDouble(fechaActual.DayOfWeek));
            DateTime fechadesdesemana = fechaMinima.Date;
            string fecha_Lunes = fechadesdesemana.Year + "/" + fechadesdesemana.Month  +  "/" + fechadesdesemana.Day;
            string fecha_Martes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(1).Day;
            string fecha_Miercoles = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(2).Day;
            string fecha_Jueves = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(3).Day;
            string fecha_Viernes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(4).Day;

            //Lunes

             var Lunes = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Lunes + "'").ToList() ;
            //var Lunes = from o in informacion.Informacion where o.fecha_salida = fecha_Lunes;
            
            for (var i = 0; i < Lunes.Count; i++)
            {
                
                var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Lunes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                list_lunes.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });

                

            }
            ViewBag.Lunes = list_lunes;

            //Martes

            var Martes = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Martes + "'").ToList();

            for (var i = 0; i < Martes.Count; i++)
            {

                var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Martes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                list_martes.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });

                

            }
            ViewBag.Martes = list_martes;

            //Miercoles

            var Miercoles = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Miercoles + "'").ToList();

            for (var i = 0; i < Miercoles.Count; i++)
            {

                var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Miercoles[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                list_miercoles.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });

               

            }
            ViewBag.Miercoles = list_miercoles;

            //Jueves

            var Jueves = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Jueves + "'").ToList();

            for (var i = 0; i < Jueves.Count; i++)
            {

                var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Jueves[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                list_jueves.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });

               

            }
            ViewBag.Jueves = list_jueves;

            //Viernes

            var Viernes = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Viernes + "'").ToList();

            for (var i = 0; i < Viernes.Count; i++)
            {

                var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Viernes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                list_viernes.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });

                

            }
            ViewBag.Viernes = list_viernes;
            
            


            return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("Ordenes/buscarOrdenes")]
        [HttpPost]
        public ActionResult Ordenes(DateTime fechaBuscar)
        {
            if (session())
            {
                List<Estado> list_lunes = new List<Estado>();
                List<Estado> list_martes = new List<Estado>();
                List<Estado> list_miercoles = new List<Estado>();
                List<Estado> list_jueves = new List<Estado>();
                List<Estado> list_viernes = new List<Estado>();

                
                DateTime fechaActual = fechaBuscar;
                DateTime fechaMinima = DateTime.MinValue;
                fechaMinima = fechaActual.AddDays(1 - Convert.ToDouble(fechaActual.DayOfWeek));
                DateTime fechadesdesemana = fechaMinima.Date;
                string fecha_Lunes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.Day;
                string fecha_Martes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(1).Day;
                string fecha_Miercoles = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(2).Day;
                string fecha_Jueves = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(3).Day;
                string fecha_Viernes = fechadesdesemana.Year + "/" + fechadesdesemana.Month + "/" + fechadesdesemana.AddDays(4).Day;

                //Lunes

                var Lunes = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Lunes + "'").ToList();
                //var Lunes = from o in informacion.Informacion where o.fecha_salida = fecha_Lunes;

                for (var i = 0; i < Lunes.Count; i++)
                {

                    var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Lunes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                    list_lunes.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });



                }
                ViewBag.Lunes = list_lunes;

                //Martes

                var Martes = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Martes + "'").ToList();

                for (var i = 0; i < Martes.Count; i++)
                {

                    var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Martes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                    list_martes.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });



                }
                ViewBag.Martes = list_martes;

                //Miercoles

                var Miercoles = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Miercoles + "'").ToList();

                for (var i = 0; i < Miercoles.Count; i++)
                {

                    var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Miercoles[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                    list_miercoles.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });



                }
                ViewBag.Miercoles = list_miercoles;

                //Jueves

                var Jueves = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Jueves + "'").ToList();

                for (var i = 0; i < Jueves.Count; i++)
                {

                    var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Jueves[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                    list_jueves.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });



                }
                ViewBag.Jueves = list_jueves;

                //Viernes

                var Viernes = db.Informacion.SqlQuery("SELECT * FROM informacion where fecha_salida =" + "'" + fecha_Viernes + "'").ToList();

                for (var i = 0; i < Viernes.Count; i++)
                {

                    var result = db.Estado.SqlQuery("SELECT num_orden , ubicacion FROM estado where num_orden =" + "'" + Viernes[i].num_orden + "'" + "order by ubicacion desc limit 1").ToList();

                    list_viernes.Add(new Estado() { num_orden = result[0].num_orden, ubicacion = result[0].ubicacion });



                }
                ViewBag.Viernes = list_viernes;




                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}