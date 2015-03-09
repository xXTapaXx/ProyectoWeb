using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using Newtonsoft.Json;

namespace ProyectoWeb.Controllers
{
    public class ClientesController : Controller
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


        // GET: Clientes
        public ActionResult Index()
        {
            if (session())
            {
                return View(db.Cliente.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Clientes/Create
        public ActionResult Create()
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

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,telefono,correo")] Cliente cliente)
        {
            if (session())
            {
                if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,telefono,correo")] Cliente cliente)
        {
            if (session())
            {
                if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (session())
            {
                Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Route("BuscarCliente/{nombre}")]
        public Object buscarCliente(string nombre)
        {
            if (session())
            {
                bool isValid = true;
            var buscarCliente = db.Cliente.SqlQuery("SELECT * FROM cliente where nombre = '" + nombre + "'").ToList();           
            if (buscarCliente.Count > 0)
            {
                isValid = false;
            }
            
            return isValid;
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("BuscarCliente")]
        public Object buscarCliente()
        {
            if (session())
            {
                bool isValid = true;
            var buscarCliente = db.Cliente.ToList();


            return JsonConvert.SerializeObject(buscarCliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("agregarCliente")]
        [HttpPost]
        public Object CrearCliente([Bind(Include = "id,nombre,apellidos,telefono,correo")] Cliente cliente)
        {
            if (session())
            {
                object idCliente = null;
            if (ModelState.IsValid)
            {
                
                db.Cliente.Add(cliente);
                db.SaveChanges();
                idCliente = db.Cliente.SqlQuery("SELECT * FROM cliente Order By id DESC limit 1").ToList();
            }


            return  JsonConvert.SerializeObject(idCliente);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
