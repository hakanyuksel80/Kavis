using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KavisWeb.Controllers.api
{
    public class KurumController : ApiController
    {
        // GET: api/Kurum
        public IEnumerable<Kurum> Get()
        {
            KurumManager manager = new KurumManager();

            var liste = manager.GetList();

            return liste;
        }

        // GET: api/Kurum/5
        public Kurum Get(int id)
        {
            KurumManager manager = new KurumManager();

            var kurum = manager.Get(id);

            return kurum;
        }

        // POST: api/Kurum
        public IResult Post(Kurum model)
        {
            KurumManager manager = new KurumManager();

            if (model.Id > 0)
            {
                Kurum kurum = manager.Get(model.Id);
                if (kurum != null)
                {
                    kurum.Adi = model.Adi;
                    kurum.KurumKodu = model.KurumKodu;
                    kurum.Turu = model.Turu;
                    kurum.AktifYil = model.AktifYil;
                    kurum.FaaliyetDurumGirisAcik = model.FaaliyetDurumGirisAcik;
                    kurum.FaaliyetGirisAcik = model.FaaliyetGirisAcik;
                    kurum.GostergeGirisAcik = model.GostergeGirisAcik;
                    kurum.Mesaj = model.Mesaj;

                    if (!manager.Update(model))
                        return new ErrorResult();
                    else
                        return new SuccessResult();
                }

                return new ErrorResult();
            }
            else if (manager.Add(model))
            {
                return new SuccessDataResult<Kurum>(model);
            }
            else
                return new ErrorResult();

        }

        // DELETE: api/Kurum/5
        public IResult Delete(int id)
        {

            KurumManager manager = new KurumManager();
            if (manager.Delete(id))
                return new SuccessResult();
            else
                return new ErrorResult();
        }
    }
}
