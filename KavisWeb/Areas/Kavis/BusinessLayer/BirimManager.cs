
using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class BirimManager
    {
        IBirimDal birimDal;

        public BirimManager(IBirimDal birimDal)
        {
            this.birimDal = birimDal;
        }

        public BirimManager()
        {
            this.birimDal = new EfBirimDal();
        }

        public List<Birim> GetAll(int kurumId = 0)
        {
            if (kurumId > 0)
            {
                return birimDal.GetAll(x => x.KurumId == kurumId);
            }
            else
                return birimDal.GetAll();
        }

        public Birim Get(int id)
        {
            return birimDal.Get(x => x.Id == id);
        }

        public bool Delete(int id)
        {
            var birim = this.Get(id);

            if (birim != null)
                return birimDal.Delete(birim);

            return false;
        }

        internal Birim GetByBurbisId(int bolumId)
        {
            return birimDal.Get(x => x.BurbisId == bolumId);
        }

        public bool Update(Birim model)
        {
            return birimDal.Update(model);
        }

        public bool Add(Birim model)
        {
            return birimDal.Add(model);
        }
    }
}