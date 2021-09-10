using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KavisWeb.Controllers.api
{
    public class BirimFaaliyetlerController : ApiController
    {
        // GET: api/BirimFaaliyetler
        public BirimFaaliyetlerViewModel Get()
        {
            return new BirimFaaliyetlerViewModel()
            {
                Faaliyetler = new List<FaaliyetItem>()
                {
                    new FaaliyetItem { Id = 1, EylemId = 1, EylemAdi = "EYLEM ADİ 1" },
                    new FaaliyetItem { Id = 2, EylemId = 2, EylemAdi = "EYLEM ADİ 1" },
                    new FaaliyetItem { Id = 3, EylemId = 3, EylemAdi = "EYLEM ADİ 1" },

                },
                 Stratejiler = new List<ParentPlanItem>()
                 {

                     new ParentPlanItem { Id = 1, Baslik="", }
                 }
            };
        }

        // POST: api/BirimFaaliyetler
        public void Post([FromBody] string value)
        {

        }

        // DELETE: api/BirimFaaliyetler/5
        public void Delete(int id)
        {

        }
    }


    public class BirimFaaliyetlerViewModel
    {
        public List<ParentPlanItem> Stratejiler { get; set; }

        public List<FaaliyetItem> Faaliyetler { get; set; }

    }

    public class FaaliyetItem
    {
        public int Id { get; set; }

        public int EylemId { get; set; }

        public string EylemAdi { get; set; }

        public string FaaliyetAdi { get; set; }

        public string Gerceklestirilenler { get; set; }

        public string Sonuc { get; set; }

        public string Durum { get; set; }
    }
}
