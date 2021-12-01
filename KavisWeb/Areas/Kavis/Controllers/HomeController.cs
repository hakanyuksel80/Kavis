using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KavisWeb.BusinessLayer;

namespace KavisWeb.Areas.Kavis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Kavis/Home
        public ActionResult Index()
        {
            var aUser =  KavisHelper.GetUser();

            switch(aUser.Type)
            {
                case Entities.KavisUserType.Birim: return RedirectToAction("Index", "KavisModul03");
                case Entities.KavisUserType.Kurum: return RedirectToAction("Index", "KavisModul02");
            }

            return View();
        }
    }
}