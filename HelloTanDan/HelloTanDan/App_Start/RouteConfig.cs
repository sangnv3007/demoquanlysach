using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloTanDan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //
            routes.MapRoute(
                name: "page-1",
                url: "page_1",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "page-2",
                url: "page_2",
                defaults: new { controller = "Page", action = "Index2", id = UrlParameter.Optional }
            );
            //
            routes.MapRoute(
                name: "detail",
                url: "detail",
                defaults: new { controller = "Book", action = "DeTailBook", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "listbook",
                url: "listbook",
                defaults: new { controller = "Book", action = "ListBook", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
