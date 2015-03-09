using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProyectoWeb.Controllers
{
    public class ProcesoController : Controller
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

        // GET: Proceso
        public ActionResult Index()
        {
            if (session())
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("Proceso/Buscar/{num_orden:int}")]
        public Object buscarOrden(int num_orden)
        {
            if (session())
            {

                var buscar = db.Estado.SqlQuery("SELECT * FROM estado INNER JOIN etapas ON estado.ubicacion = etapas.ubicacion INNER JOIN informacion ON estado.num_orden = informacion.num_orden WHERE estado.num_orden = '" + num_orden + "' order By estado.ubicacion DESC limit 1").ToList();
          
            var retorno = JsonConvert.SerializeObject(buscar);

            return retorno;
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("Proceso/Asignar/{num_orden:int}/{ubicacion:int}")]
        public Object PruebaORden(int num_orden, int ubicacion)
        {
            if (session())
            {

                // var insertar = estado.Estado.SqlQuery("INSERT INTO estado(num_orden, ubicacion) VALUES ('" + num_orden + "','" + ubicacion + "')");
                var buscar = db.Estado.SqlQuery("SELECT * FROM estado where num_orden='" + num_orden + "' and ubicacion = '" + ubicacion + "'").ToList();
            if (buscar.Count == 0)
            {
                var asignar = db.Estado.Create();
                asignar.num_orden = num_orden;
                asignar.ubicacion = ubicacion;

                    db.Estado.Add(asignar);
                    db.SaveChanges();


                    if (ubicacion == 5)
                    {
                        var buscarNumero = db.Cliente.SqlQuery("SELECT * FROM cliente INNER JOIN informacion ON informacion.idcliente = cliente.id  WHERE informacion.num_orden = '" + num_orden + "'").ToList();
                        var mensaje = "Imprenta Sancarlos le informa que su pedido ha finalizado";
                        var numero = buscarNumero[0].telefono;
                        //var numero = buscarNumero.numero;
                        SerialPort _serialPort = new SerialPort("COM5", 115200);
                        _serialPort.Open();

                        Thread.Sleep(1000);
                        _serialPort.Write("AT+CMGF=1\r");

                        Thread.Sleep(1000);
                        _serialPort.Write("AT+CMGS=\"" + numero + "\"\r\n");

                        Thread.Sleep(1000);
                        _serialPort.Write(mensaje + "\x1A");

                    }

                }
               return ubicacion;
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }
        }
}