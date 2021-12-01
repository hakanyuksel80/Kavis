using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;

namespace KavisWeb.Controllers.api
{
    [SessionState(SessionStateBehavior.Required)]
    public class FaaliyetDurumController : ApiController
    {
        FaaliyetManager manager = new FaaliyetManager(new EfFaaliyetDal());

        public FaaliyetDurumView Get(int id)
        {
            var faaliyet = manager.Get(id);

            return new FaaliyetDurumView()
            {
                Id = faaliyet.Id,
                FaaliyetAdi = faaliyet.Baslik,
                Baslama = faaliyet.Baslama,
                Bitis = faaliyet.Bitis,
                Durum = faaliyet.Durum,
                EylemAdi = faaliyet.Eylem.Baslik,                
                Gerceklesme = faaliyet.Gerceklesme,
                Sonuc = faaliyet.Sonuc,
            };

        }

        // POST: api/Faaliyet
        public IResult Post(FaaliyetDurumView model)
        {
            var faaliyet = manager.Get(model.Id);

            if (faaliyet != null)
            {
                faaliyet.Baslama = model.Baslama;
                faaliyet.Bitis = model.Bitis;
                faaliyet.Durum = model.Durum??"";
                faaliyet.Gerceklesme = model.Gerceklesme??"";
                faaliyet.Sonuc = model.Sonuc??"";

                if (manager.Update(faaliyet))
                    return new SuccessResult();
            }                   

            return new ErrorResult("Kayıt yapılamadı");
        }

    }
}
