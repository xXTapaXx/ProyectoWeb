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
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login([Bind(Include = "user,contrasena")] Usuario usuario)
        {
            
                if (IsValid(usuario.user, usuario.contrasena))
                {
                    FormsAuthentication.SetAuthCookie(usuario.user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario Incorrecto"); 
                }
            
            return View(usuario);
        }

        private bool IsValid(string user, string password)
        {
            

            bool isValid = false;

            using (var dbContext = new UsuarioDbContext())
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