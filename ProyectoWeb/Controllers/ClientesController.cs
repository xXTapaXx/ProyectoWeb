using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class ClientesController : Controller
    {
        /* 20/02/2015 Jason Gamboa
        Hacemos una instancia para abrir la conexion a la base de datos de la tabla cliente*/
        private ClienteDbContext db = new ClienteDbContext();

        /* 20/02/2015 Jason Gamboa
        Traemos todos los clientes de la tabla cliente*/
        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        /* 20/02/2015 Jason Gamboa
        Metodo para observar el detalle del cliente*/
        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            /* 20/02/2015 Jason Gamboa
            if para saber si el id es nulo*/
            if (id == null)
            {
                /* 20/02/2015 Jason Gamboa
              Si el id es nulo retorna un error */
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* 20/02/2015 Jason Gamboa
            Si no es nulo creamos un cliente y buscamos en la base de datos el cliente que coincida con el id*/
            Cliente cliente = db.Cliente.Find(id);

            /* 20/02/2015 Jason Gamboa
            if para saber si se encontro algun cliente en la base de datos*/
            if (cliente == null)
            {
                /* 20/02/2015 Jason Gamboa
                    Si no se encontro retorna un error de Not Found*/
                return HttpNotFound();
            }

            /* 20/02/2015 Jason Gamboa
            Si lo encontro retorna ese cliente a la vista*/
            return View(cliente);
        }


        /* 20/02/2015 Jason Gamboa
           Metodo que muestra la vista de crear cliente*/
        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        /* 20/02/2015 Jason Gamboa
         Metodo que recibe el cliente por medio de post para crearlo*/
        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,telefono,correo")] Cliente cliente)
        {
            /* 20/02/2015 Jason Gamboa
            if para validar que el modelo sea valido*/
            if (ModelState.IsValid)
            {
                /* 20/02/2015 Jason Gamboa
                Agregamos el cliente a la base de datos*/
                db.Cliente.Add(cliente);

                /* 20/02/2015 Jason Gamboa
                Salvamos los cambios del cliente en la base de datos*/
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            /* 20/02/2015 Jason Gamboa
            Retorna cliente*/
            return View(cliente);
        }

        // GET: Clientes/Edit/5

        public ActionResult Edit(int? id)
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

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,telefono,correo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);                     
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
