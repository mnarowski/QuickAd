﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QuickAd.Models;
using System.IO;
namespace QuickAd.Controllers
{
    public class AdvertController : Controller
    {
        //
        // GET: /Advert/


        public ActionResult Index(FormCollection collection)
        {
            int id_territory = Int32.Parse(collection["territory"]);
            int id_category = Int32.Parse(collection["category"]);

            NHibernate.IQuery query = SessionFactory.GetNewSession().CreateQuery("from Advertise a WHERE a.VidAdvertCategory=:id_category AND a.VidTerritory=:id_territory").
                SetParameter<int>("id_category", id_category).
                SetParameter<int>("id_territory", id_territory);
            
            List<Advertise> adverts = (List<Advertise>)query.List<Advertise>();
            
            ViewData.Model = adverts;
            return View();     
        }

        public ActionResult Details(int id)
        {
            Advertise model = DBHelper.FindOne<Advertise>(id);
            ViewData.Model = model;
            ViewBag.id = model.GetId();
            ViewData["copyModel"] = model;
            model.IncrementVisitsCount();
            DBHelper.SaveOrUpdate(model);
            return View();
        }

        public ActionResult Create()
        {
            if (Session["User"] == null) {
                return RedirectToAction("Error", "Home");
            }
            Advertise model = new Advertise();
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Advertise advertise = new Advertise();
                advertise.SetAddinationalInfo(collection["VadditionalInfo"] as string);
                advertise.SetAdvertCategory(DBHelper.FindOne<AdvertCategory>(Int32.Parse(collection["category"])));
                advertise.VidTerritory = Int32.Parse(collection["territory"]);
                advertise.SetContent(collection["Vcontent"]);
                advertise.SetPrice(Double.Parse(collection["Vprice"]));
                advertise.SetTitle(collection["Vtitle"] as string);
                DateTime validity = DateTime.Now;
                validity.AddDays(20);
                advertise.SetValidity(validity);
                advertise.SetVisibleToOthers(true);
                advertise.SetVisits(0);
                advertise.VidUser = ((User)Session["User"]).GetId();
                DBHelper.SaveOrUpdate(advertise);

                return RedirectToAction("Edit", new {id=advertise.GetId() });
            }
            catch
            {
                ViewBag.Message = "Wystąpił błąd podczas dodawania - powiadom Administrację";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Advertise model = DBHelper.FindOne<Advertise>(id);
            ViewData.Model = model;
            
           if (Session["User"]==null || (!((User)Session["User"]).IsOwner(model) && !((User)Session["User"]).IsAdmin())) {
              return RedirectToAction("Error", "Home");
           }
            ViewData["copyModel"] = model;
            
            return View();
        }

        //
        // POST: /Advert/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Advertise advertise = DBHelper.FindOne<Advertise>(id);

                advertise.SetAddinationalInfo(collection["VaddinationInfo"] as string);
                advertise.SetAdvertCategory(DBHelper.FindOne<AdvertCategory>( Int32.Parse(collection["category"])));
                advertise.SetContent(collection["Vcontent"]);
                advertise.SetPrice(Double.Parse(collection["Vprice"]));
                advertise.SetTitle(collection["Vtitle"] as string);
                advertise.VidTerritory = Int32.Parse(collection["territory"]);
                
                DBHelper.SaveOrUpdate(advertise);
                foreach (string file in Request.Files)
                {
                    var hpf = this.Request.Files[file];
                    if (hpf.ContentLength == 0)
                    {
                        continue;
                    }

                    QuickAd.Models.Image img = new QuickAd.Models.Image();


                    string savedFileName = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Uploads");
                    
                    savedFileName = Path.Combine(savedFileName, ((User)Session["User"]).AsString()+Path.GetFileName(hpf.FileName));
                    img.SetExtension(Path.GetExtension(hpf.FileName));
                    img.SetImagePath(savedFileName.Replace(AppDomain.CurrentDomain.BaseDirectory,"").Replace("\\","/"));
                    img.VidAdvertise = advertise.Vid;
                    DBHelper.SaveOrUpdate(img);

                    hpf.SaveAs(savedFileName);
                }  
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /Advert/Delete/5

        public ActionResult Delete(int id)
        {
            DBHelper.Delete(DBHelper.FindOne<Advertise>(id));

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
             return Delete(id);
            }
            catch
            {
                return View();
            }
        }
       
       public ActionResult Removes(int id)
       {
            QuickAd.Models.Image img = DBHelper.FindOne<QuickAd.Models.Image>(id);
            string savedFileName = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, img.GetImagePath());

            System.IO.File.Delete(savedFileName);
            DBHelper.Delete(img);
            return Json(new { result = true, message = "Zdjęcie usunięto!" },JsonRequestBehavior.AllowGet);
        
       }


       public ActionResult Rate(FormCollection collection) {
           AdvertRate rate = new AdvertRate();
           rate.VidAdvertise = Int32.Parse(collection["advertise"]);
           rate.Vrate = Int32.Parse(collection["Vrate"]);
           DBHelper.SaveOrUpdate(rate);
           return Redirect(collection["redirect_ok"]);
       }
       [HttpPost]
       public ActionResult Comment(FormCollection collection) {
           Comment comment = new Comment();
           comment.Vcontent = collection["Vcontent"];
           comment.VcreatedDate = DateTime.Now;
           comment.Vtitle = collection["Vtitle"];
           comment.VidUser = ((User)Session["User"]).Vid;
           comment.VidAdvertise = Int32.Parse(collection["creator"]);
           DBHelper.SaveOrUpdate(comment);
           return Redirect(collection["redirect_ok"]);
       }

       public ActionResult DeleteComment(int id) {
           Comment cToDelete = DBHelper.FindOne<Comment>(id);
           int advertLinkId = cToDelete.VidAdvertise;
           DBHelper.Delete(cToDelete);

           return RedirectToAction("Details", new { id = advertLinkId });
       }
    }
}
