using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using System.Web.Helpers;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace ProyectoWeb.Controllers
{
    public class UsuariosController : Controller
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

        // GET: Usuarios
        public ActionResult Index()
        {
            if (session())
            {

                return View(db.Usuario.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Usuarios/Create
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

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,departamento,user,contrasena")] Usuario usuario)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {

                    usuario.contrasena = Crypto.Hash(usuario.contrasena);
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,departamento,user,contrasena")] Usuario usuario)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (session())
            {
                Usuario usuario = db.Usuario.Find(id);
                db.Usuario.Remove(usuario);
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
        [Route("validar")]
        public object validar()
        {
            if (session())
            {
                var retorno = db.Usuario.SqlQuery("SELECT * from usuario where user = '" + Request.Cookies["userName"].Value + "'").ToList();

                return JsonConvert.SerializeObject(retorno);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}
