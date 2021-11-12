using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class KurumManager 
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

        public List<Kurum> GetListByUser(KavisUser kavisUser)
        {
            if (kavisUser.Type == KavisUserType.Admin)
            {
                return GetList();
            }
            else if (kavisUser.Type == KavisUserType.Kurum)
            {
                return _dal.GetAll(x=>x.Id == kavisUser.KurumId);
            }

            return new List<Kurum>();
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

        public List<Kurum> GetList(KavisUser kavisUser)
        {
            if (kavisUser.Type == KavisUserType.Kurum)
            {
                return _dal.GetAll(x => x.Id == kavisUser.KurumId);
            }
            else if (kavisUser.Type == KavisUserType.Admin)
            {
                return _dal.GetAll();
            }

            return new List<Kurum>();
        }
    }
}