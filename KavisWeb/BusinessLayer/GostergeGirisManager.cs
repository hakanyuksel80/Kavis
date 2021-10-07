using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class GostergeGirisManager : IGostergeGirisService
    {

        IGostergeGirisDal girisDal;

        public GostergeGirisManager(IGostergeGirisDal dal)
        {
            this.girisDal = dal;
        }

        public GostergeGiris GetByBirim(int birimId, int gostergeId, byte yil)
        {
            return girisDal.Get(x => x.GostergeId == gostergeId && x.Yil == yil && x.BirimId == birimId);
        }

        public void Add(GostergeGiris gostergeGiris)
        {
            girisDal.Add(gostergeGiris);
        }

        public void Update(GostergeGiris gostergeGiris)
        {
            girisDal.Update(gostergeGiris);
        }
    }
}