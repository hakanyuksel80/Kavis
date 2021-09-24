using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KavisWeb.Controllers.api
{
    public class BirimGostergelerController : ApiController
    {


        public IResult Post(GostergeModel model)
        {
            StratejikPlanManager2 manager = new StratejikPlanManager2();

            foreach (var item in model.Items)
            {
                var gosterge = manager.GetGosterge(item.GostergeId);

                if (gosterge != null)
                {
                    switch (item.Yil)
                    {
                        case 1: gosterge.Yil1G = item.Value; break;
                        case 2: gosterge.Yil2G = item.Value; break;
                        case 3: gosterge.Yil3G = item.Value; break;
                        case 4: gosterge.Yil4G = item.Value; break;
                        case 5: gosterge.Yil5G = item.Value; break;
                    }
                }

                manager.SaveChanges();
            }


            return new SuccessResult();
        }
    }

    public class GostergeModel
    {
       public List<GostergeModelItem> Items { get; set; }
    }

    public class GostergeModelItem
    {
        public int GostergeId { get; set; }

        public string Value { get; set; }

        public int Yil { get; set; }

    }
}
