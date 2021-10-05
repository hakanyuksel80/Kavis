using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
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

            GostergeGirisManager gostergeGirisManager = new GostergeGirisManager(new EfGostergeGirisDal());

            if (model.Items != null)
                foreach (var item in model.Items)
                {
                    var gosterge = manager.GetGosterge(item.GostergeId);

                    if (gosterge != null)
                    {
                        var gostergeGiris = gostergeGirisManager.GetByBirim(model.BirimId, item.GostergeId, (byte)item.Yil);

                        if (gostergeGiris == null)
                        {
                            gostergeGiris = new Enitites.DbModels.GostergeGiris()
                            {
                                BirimId = model.BirimId,
                                GostergeId = item.GostergeId,
                                Onay = false,
                                Yil = (byte)item.Yil,
                                Deger = item.Value,
                            };

                            gostergeGirisManager.Add(gostergeGiris);

                        }
                        else
                        {
                            gostergeGiris.Deger = item.Value;
                            gostergeGirisManager.Update(gostergeGiris);
                        }

                    }

                    manager.SaveChanges();
                }


            return new SuccessResult();
        }
    }

    public class GostergeModel
    {
        public int BirimId { get; set; }

        public List<GostergeModelItem> Items { get; set; }
    }

    public class GostergeModelItem
    {
        public int GostergeId { get; set; }

        public string Value { get; set; }

        public int Yil { get; set; }

    }
}
