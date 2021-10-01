using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class KurumManager : IKurumService
    {
        IKurumDal _dal;

        public KurumManager()
        {
            _dal = new EfKurumDal();
        }
        public List<Kurum> GetList()
        {
            return _dal.GetAll();
        }

        public Kurum Get(int id)
        {
            return _dal.Get(x => x.Id == id);
        }

        public bool Update(Kurum model)
        {
            return _dal.Update(model);
        }

        public bool Add(Kurum model)
        {
            return _dal.Add(model);
        }

        public bool Delete(int id)
        {
            Kurum kurum = Get(id);
            if (kurum != null)
                return _dal.Delete(kurum);

            return false;              
        }
    }
}