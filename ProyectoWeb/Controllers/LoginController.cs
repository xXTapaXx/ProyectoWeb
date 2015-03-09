using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoWeb.Controllers
{
    public class LoginController : Controller
    {
        private ImprentaContext db = new ImprentaContext(); 
        HttpCookie aCookie;
        // GET: Login
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
        public ActionResult Index()
        {
            if (session())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult login()
        {
            if (session())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login([Bind(Include = "user,contrasena")] Usuario usuario)
        {

            if (IsValid(usuario.user, usuario.contrasena))
            {
                Response.Cookies["userName"].Value = usuario.user;
                         
                aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Usuario Incorrecto");
            }

            return View(usuario);
        }

        public ActionResult logout()
        {
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }

            return RedirectToAction("Index", "Login");
        }
        private bool IsValid(string user, string password)
        {


            bool isValid = false;

            using (var dbContext = new ImprentaContext())
            {
                var usuario = dbContext.Usuario.FirstOrDefault(u => u.user == user);

                if (usuario != null)
                {
                    var encrpPass = Crypto.Hash(password);
                    if (usuario.contrasena == encrpPass)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }




    }
}