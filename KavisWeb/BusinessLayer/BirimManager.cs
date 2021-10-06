using KavisWeb.DataLayer.Abstract;
using KavisWeb.Enitites.DbModels;
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