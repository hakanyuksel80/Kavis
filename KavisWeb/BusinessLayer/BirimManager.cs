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

        public List<Birim> GetAll()
        {
            return birimDal.GetAll();
        }
    }
}