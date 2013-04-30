using System;
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
                advertise.VidUser = ((User)Session["User"]).GetId();
                DBHelper.SaveOrUpdate(advertise);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Advertise model = DBHelper.FindOne<Advertise>(id);
            ViewData.Model = model;
            
           //if (Session["User"]==null || (!((User)Session["User"]).IsOwner(model) && !((User)Session["User"]).IsAdmin())) {
           //    return RedirectToAction("Error", "Home");
           // }
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
                    /*Session["User"].ToString() +*/
                    savedFileName = Path.Combine(savedFileName, Path.GetFileName(hpf.FileName));
                    img.SetExtension(Path.GetExtension(hpf.FileName));
                    img.SetImagePath(savedFileName);
                    img.VidAdvertise = advertise.Vid;
                    DBHelper.SaveOrUpdate(img);

                    hpf.SaveAs(savedFileName);
                }  
                return RedirectToAction("Index","Home");
            }
            catch(Exception e)
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
