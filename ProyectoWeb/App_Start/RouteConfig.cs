using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "proceso",
                url: "{controller}/{action}/{id}/{id2}",
                defaults: new { controller = "Proceso", action = "Index", id = UrlParameter.Optional, id2 = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "buscarOrden",
               url: "{controller}/{action}/{buscar}",
               defaults: new { controller = "BuscarOrden", action = "Index", buscar = UrlParameter.Optional}
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}