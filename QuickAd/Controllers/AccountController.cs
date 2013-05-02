using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using WebMatrix.WebData;
using QuickAd.Filters;
using QuickAd.Models;

namespace QuickAd.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login(string redirect_ok) {
            ViewBag.RedirectUrl = redirect_ok;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection) {
            if(Authorize(collection)){
                //string u = (collection["redirect_ok"] == null || collection["redirect_ok"] == String.Empty) ? "/" : collection["redirect_ok"];
                return RedirectToAction("Index","Home");
            }
            ViewBag.Message = "Nie znaleziono użytkownika!";
            return View();
        }

        private bool Authorize(FormCollection collection)
        {
            if (Session["User"] != null) {
                //collection["redirect_ok"] = (collection["redirect_ok"] == null) ? "/" : collection["redirect_ok"];
                return true;
            }
            String login = collection["Vemail"];
            String password = collection["Vpassword"];
            User u =SessionFactory.GetNewSession().CreateQuery("from User u WHERE u.Vemail=:email AND u.Vpassword=:pass")
                .SetParameter("email", login)
                .SetParameter("pass", password).UniqueResult<User>();
            if (u != null) 
            {
                Session["User"] = u;
                return true;
            }

            return false;
        }

        public ActionResult Logout() {
            Session["User"] = null;

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            if (Session["User"] == null) {
                return RedirectToAction("Error", "Home");
            }
            User sessionUser = (User)Session["User"];
            if (sessionUser.Vid != id) {
                return RedirectToAction("Error", "Home");
            }
            User u = DBHelper.FindOne<User>(id);
            ViewData.Model = u;
            ViewData["copyModel"] = u;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (Session["User"] == null)
            {
                return RedirectToAction("Error", "Home");
            }
            User sessionUser = (User)Session["User"];
            if (sessionUser.Vid != id)
            {
                return RedirectToAction("Error", "Home");
            }
            User u = sessionUser;

            Session["User"] = u;
            DBHelper.SaveOrUpdate(u);
            return RedirectToAction("Edit", new { id = u.Vid });
        }

        [HttpGet]
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection) {
            return RedirectToAction("Register");
        }

        [HttpGet]
        public ActionResult Admin()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Error", "Home");
            }
            User sessionUser = (User)Session["User"];
            if (!sessionUser.IsAdmin())
            {
                return RedirectToAction("Error", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Admin(FormCollection collection) {
            return new JsonResult();        
        }
    }
}
