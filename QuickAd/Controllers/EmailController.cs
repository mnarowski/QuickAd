using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickAd.Models;

namespace QuickAd.Controllers
{
    public class EmailController : Controller
    {


        [HttpPost]
        public ActionResult Add(FormCollection collection) {
            if(Session["User"] == null){
                return RedirectToAction("Error","Home");
            }
            Email email = new Email(DBHelper.FindOne<User>(Int16.Parse(collection["creator"])));
            email.SetSenderUser((User)Session["User"]);
            email.Vcontent = collection["Vcontent"];
            email.Vtitle = collection["Vtitle"];
            email.VcreatedDate = DateTime.Now;
            DBHelper.SaveOrUpdate(email);
            EmailSenderService.SendEmail(email);
            return Redirect(collection["redirect_ok"]);
        }
    }
}
