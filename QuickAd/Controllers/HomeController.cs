using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickAd.Models;

namespace QuickAd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Categories = DBHelper.GetAll<AdvertCategory>();
            ViewBag.Regions = DBHelper.GetAll<Territory>();
            ViewBag.Message = "Witaj w aplikacji QUickAd";//"Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Contact() {
            return View();
        }

        public ActionResult Error() {
            return View();
        }

    }
}
