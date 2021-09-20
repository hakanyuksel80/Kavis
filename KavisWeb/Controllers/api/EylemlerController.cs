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
        public static ParentPlanItem Eylemler = new ParentPlanItem()
        {
            Items = new List<ParentPlanItem>()
            {
                new ParentPlanItem() {
                    Id = 1,
                    Baslik = "STRATEJİM",
                    No = "1.1.1",
                    SiraNo = 1,
                    Items = new List<ParentPlanItem>() {
                        new ParentPlanItem() { Id = 2 , Baslik = "Eylemim", No = "1.1.1.1", SiraNo = 1 },
                        new ParentPlanItem() { Id = 3 , Baslik = "Eylemim", No = "1.1.1.2", SiraNo = 2 },
                        new ParentPlanItem() { Id = 4 , Baslik = "Eylemim", No = "1.1.1.2", SiraNo = 2 },
                    }
                }
                ,new ParentPlanItem
                {
                    Id = 5, Baslik = "Stratejiler 2", No = "1.1.2", Items = new List<ParentPlanItem>()
                    {
                         new ParentPlanItem() { Id = 6 , Baslik = "Eylemsiz", No = "1.1.2.1", SiraNo = 1 },
                        new ParentPlanItem() { Id = 7 , Baslik = "Eylemimiiiii", No = "1.1.2.2", SiraNo = 2 },
                    },
                }
            }
        };


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
        public void Post([FromBody] string eylemler)
        {
            //Eylemler = list;
        }

    }
}
