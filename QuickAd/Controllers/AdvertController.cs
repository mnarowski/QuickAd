using System;
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
                advertise.SetAddinationalInfo(collection["addinationInfo"] as string);
                advertise.SetAdvertCategory(DBHelper.FindOne<AdvertCategory>(id: Int32.Parse(collection["category"])));
                advertise.SetContent(collection["content"]);
                advertise.SetHash(DBHelper.generateHash());
                advertise.SetPrice(Double.Parse(collection["price"]));
                advertise.SetTitle(collection["title"] as string);
                DateTime validity = new DateTime();
                validity.AddDays(20);
                advertise.SetValidity(validity);
                advertise.SetVisibleToOthers(true);
                advertise.SetVisits(0);
                DBHelper.SaveOrUpdate(advertise);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Advertise model = DBHelper.FindOne<Advertise>(id);
            ViewData.Model = model;
            
            if (Session["User"]!=null || (!((User)Session["User"]).IsOwner(model) && !((User)Session["User"]).IsAdmin())) {
                return RedirectToAction("Index", "Home");
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

                advertise.SetAddinationalInfo(collection["addinationInfo"] as string);
                advertise.SetAdvertCategory(DBHelper.FindOne<AdvertCategory>(id: Int32.Parse(collection["category"])));
                advertise.SetContent(collection["content"]);
                advertise.SetHash(DBHelper.generateHash());
                advertise.SetPrice(Double.Parse(collection["price"]));
                advertise.SetTitle(collection["title"] as string);
                DBHelper.SaveOrUpdate(advertise);
                
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
             return Delete(id);
            }
            catch
            {
                return View();
            }
        }
    }
}
