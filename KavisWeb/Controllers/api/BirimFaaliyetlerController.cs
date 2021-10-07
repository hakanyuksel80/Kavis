using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.DbModels;
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
        public BirimFaaliyetlerViewModel Get(int id)
        {
            var model = new BirimFaaliyetlerViewModel();

            FaaliyetManager manager = new FaaliyetManager(new EfFaaliyetDal());

            var faaliyetler = manager.GetAll(id);

            model.Faaliyetler = (from x in faaliyetler
                                 select new FaaliyetItem { Id = x.Id, Durum = x.Durum, EylemAdi = x.Eylem.KodVeBaslik, EylemId = x.EylemId, FaaliyetAdi = x.Baslik, Gerceklestirilenler = x.Gerceklesme, Sonuc = x.Sonuc }).ToList();


            return model;

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
