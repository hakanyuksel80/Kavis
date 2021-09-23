using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KavisWeb.Controllers.api
{
    public class EylemlerController : ApiController
    {
        
        IStratejikPlanService stratejikPlanManager = null;

        public EylemlerController()
        {
            this.stratejikPlanManager = new StratejikPlanManager2();
        }

        // GET: api/Eylemler
        public ParentPlanItem Get(int id)
        {
            var stratejiler = stratejikPlanManager.GetAllStrateji(id);

            List<ParentPlanItem> parents = new List<ParentPlanItem>();

            int parentSiraNo = 0;

            foreach (var item in stratejiler)
            {
                var stratejiItem = new ParentPlanItem()
                {
                    Id = item.Id,
                    Baslik = item.Baslik,
                    No = item.Kod,
                    SiraNo = ++parentSiraNo,
                    Items = new List<ParentPlanItem>(),
                };

                List<Eylem> eylemler = stratejikPlanManager.GetListEylemByStrateji(item.Id);

                int subSiraNo = 0;
                foreach (var aEylem in eylemler)
                {
                    stratejiItem.Items.Add(new ParentPlanItem()
                    {
                        Id = aEylem.Id,
                        ParentId = item.Id,
                        Baslik = aEylem.Baslik,
                        Birim = aEylem.Birim,
                        No = aEylem.Kod,
                        SiraNo = ++subSiraNo,
                    });
                }

                parents.Add(stratejiItem);
            }

            return new ParentPlanItem
            {
                Items = parents
            };


        }

        // POST: api/Eylemler
        public void Post([FromBody]ParentPlanItem model)
        {
            var manager = this.stratejikPlanManager;
            //Eylemler = list;
            Strateji strateji = null;
            int stratejiId = 0;
            int siraNo = 0;

            foreach (var modelEylem in model.Items)
            {
                Eylem eylem = null;
                if (modelEylem.Id > 0)
                {
                    eylem = manager.GetEylem(modelEylem.Id);
                }
                else
                    eylem = new Eylem();

                if (stratejiId != modelEylem.ParentId)
                {
                    stratejiId = modelEylem.ParentId;
                    siraNo = 0;
                    strateji = manager.GetStrateji(stratejiId);
                }    

                eylem.Baslik = modelEylem.Baslik;
                eylem.Birim = modelEylem.Birim;
                eylem.SiraNo = ++siraNo;
                eylem.Kod = strateji.Kod+"."+siraNo;                
                eylem.StratejiId = modelEylem.ParentId;
                eylem.Strateji = strateji;

                if (eylem.Id == 0)
                    manager.AddEylem(eylem);
            }

            manager.SaveChanges();
        }

    }
}
