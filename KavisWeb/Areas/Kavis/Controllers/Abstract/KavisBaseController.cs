using KavisWeb.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Areas.Kavis.Controllers
{
    public abstract class KavisBaseController : Controller
    {

        protected IKavisHelper kavisHelper;

        public KavisBaseController()
        {
            
        }

        public PartialViewResult UserMenu()
        {
            var kavisUser = kavisHelper.GetUser();

            return PartialView(kavisUser);
        }
    }
}