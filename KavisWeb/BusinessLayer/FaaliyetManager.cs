using KavisWeb.DataLayer.Abstract;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class FaaliyetManager : IFaaliyetService
    {
        IFaaliyetDal faaliyetDal;

       

        public FaaliyetManager(IFaaliyetDal birimDal)
        {
            this.faaliyetDal = birimDal;
        }

        public List<Faaliyet> GetAll(int birimId)
        {
            if (birimId > 0)
            {
                return faaliyetDal.GetAll(x => x.Birim == birimId);
            }
            else
                return faaliyetDal.GetAll();
        }

        public Faaliyet Get(int id)
        {
            return faaliyetDal.Get(x => x.Id == id);
        }

        public bool Delete(int id)
        {
            var faaliyet = this.Get(id);

            if (faaliyet != null)
                return faaliyetDal.Delete(faaliyet);

            return false;
        }

        public bool Update(Faaliyet model)
        {
            return faaliyetDal.Update(model);
        }

        public bool Add(Faaliyet model)
        {
            return faaliyetDal.Add(model);
        }
    }
}