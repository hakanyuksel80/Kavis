using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;

namespace BurbisMVC.Areas.Kavis.BusinessLayer
{
    public static class DalGenerate
    {
        public static IBirimDal CreateBirimDal()
        {
            return new EfBirimDal();
        }
    }
}