﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QuickAd.Models;
namespace QuickAd.Controllers
{
    public class AdvertController : Controller
    {
        //
        // GET: /Advert/

        public ActionResult Index()
        {
            List<Advertise> adverts = DBHelper.GetAll<Advertise>();
            ViewBag.List = adverts;
            return View();
        }

        public ActionResult Index(FormCollection collection)
        {
             
            return View();
        }

        //
        // GET: /Advert/Details/5

        public ActionResult Details(int id)
        {
            Advertise model = DBHelper.FindOne<Advertise>(id);
            ViewBag.Model = model;
            return View();
        }

        //
        // GET: /Advert/Create

        public ActionResult Create()
        {
            Advertise model = new Advertise();
            ViewBag.Model = model;
            return View();
        }

        //
        // POST: /Advert/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Advert/Edit/5

        public ActionResult Edit(int id)
        {
            Advertise model = DBHelper.FindOne<Advertise>(id);
            ViewBag.Model = model;
            return View();
        }

        //
        // POST: /Advert/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Advertise model = DBHelper.FindOne<Advertise>(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Advert/Delete/5

        public ActionResult Delete(int id)
        {
            DBHelper.Delete(DBHelper.FindOne<Advertise>(id));

            return RedirectToAction("Index");
        }

        //
        // POST: /Advert/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Delete(id);
//                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
