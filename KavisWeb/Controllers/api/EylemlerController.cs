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

        // GET: api/Eylemler
        public ParentPlanItem Get(int id)
        {
            return EylemlerController.Eylemler;
        }              

        // POST: api/Eylemler
        public void Post([FromBody] string eylemler)
        {
            //Eylemler = list;
        }
        
    }
}
