﻿using System;
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
        public ActionResult Edit() {
            if (Session["User"] == null) {
                return RedirectToAction("Error", "Home");
            }
            User sessionUser = (User)Session["User"];

            User u = sessionUser;

            ViewBag.Adverts = SessionFactory.
                                GetNewSession().
                                CreateQuery("from Advertise adv WHERE adv.VidUser=:id_user").
                                SetParameter<int>("id_user", u.Vid).
                                List<Advertise>();
            ViewData.Model = u;
            ViewData["copyModel"] = u;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection) {
            if (Session["User"] == null)
            {
                return RedirectToAction("Error", "Home");
            }
            User sessionUser = (User)Session["User"];
            
            User u = sessionUser;
            u.VfirstName = collection["VfirstName"];
            u.VlastName = collection["VlastName"];
            u.VdateOfBirth = DateTime.Parse(collection["VdateOfBirth"]);
            u.Vcity = collection["Vcity"];
            u.VbuildingNumber = Int32.Parse(collection["VbuildingNumber"]);
            u.VhomeNumber = Int32.Parse(collection["VhomeNumber"]);
            u.Vstreet = collection["Vstreet"];
            u.VidSex = Int32.Parse(collection["VSex"]);
            u.VphoneNumber = collection["VphoneNumber"];
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
            User user = new User();
            string email = collection["Vemail"];
            User u = SessionFactory.GetNewSession().CreateQuery("from User u WHERE u.Vemail = :email").SetParameter("email", email).UniqueResult<User>();
            if (u != null) {
                ViewBag.Message = "Login na podany adres istnieje";
                return View();
            }

            user.SetEmail(email);
            user.SetPassword(collection["Vpassword"]);
            user.Vprivillage = 1;
            user.VidSex = Int32.Parse(collection["VSex"]);
            user.SetStreet(collection["VStreet"]);
            user.SetLastName(collection["VlastName"]);
            user.SetFirstName(collection["VfirstName"]);
            user.SetDateOfBirth(DateTime.Parse(collection["VdateOfBirth"]));
            user.SetCity(collection["Vcity"]);
            user.SetBuildingNumber(Int32.Parse(collection["VbuildingNumber"]));
            user.SetPhoneNumber(collection["VphoneNumber"]);
            user.SetHomeNumber(Int32.Parse(collection["VhomeNumber"]));
            DBHelper.SaveOrUpdate(user);
            return RedirectToAction("Login", "Account");
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
            string type = collection["type"];
            string name = collection["value"];
            int id = Int32.Parse(collection["id"]);
            bool res = false;
            if (name.Length > 3 && name.Length < 32) {
                if (type.Equals("terrority"))
                {
                    res = EditTerritory(id, name);
                }

                if (type.Equals("advertcategory")) {
                    res = EditAdvertCategory(id, name);
                }
            }
            return Json(new { result = res });        
        }

        private bool EditTerritory(int id, string name)
        {
            NHibernate.IQuery fetch = SessionFactory.GetNewSession().CreateQuery("from Territory t WHERE t.Vname=:name")
                .SetParameter<string>("name", name);
            List<Territory> listT = (List<Territory>)fetch.List<Territory>();
            if (listT.Capacity > 0)
            {
                return false;
            }

            Territory territory = DBHelper.FindOne<Territory>(id);
            territory.Vname = name;
            DBHelper.SaveOrUpdate(territory);
            return true;
        }

        private bool EditAdvertCategory(int id, string name)
        {
            NHibernate.IQuery fetch = SessionFactory.GetNewSession().CreateQuery("from AdvertCategory t WHERE t.Vname=:name")
                .SetParameter<string>("name", name);
            List<AdvertCategory> listT = (List<AdvertCategory> )fetch.List<AdvertCategory>();
            if (listT.Capacity > 0)
            {
                return false;
            }

            AdvertCategory territory = DBHelper.FindOne<AdvertCategory>(id);
            territory.SetName(name);
            DBHelper.SaveOrUpdate(territory);
            return true;
        }
    }
}
