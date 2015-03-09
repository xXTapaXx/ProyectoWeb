using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS.Controllers
{
    public class HomeController : Controller
    {
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
                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult About()
        {
            if (session())
            {
                ViewBag.Message = "Your application description page.";

            return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Contact()
        {
            if (session())
            {
                ViewBag.Message = "Your contact page.";

            return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}