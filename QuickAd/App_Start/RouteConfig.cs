﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuickAd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Zaloguj",
            url: "zaloguj/{redirect_ok}",
            defaults: new { controller = "Account", action = "Login", redirect_ok = "/" }
                );

            routes.MapRoute(
               name: "Usuwanie fotek",
               url: "usun-fotke/{id}",
               defaults: new { controller = "Advert", action = "Removes", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}