using Core.DataAccess.EntityFramework;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace KavisWeb.DataLayer.EF
{
    public class EfFaaliyetDal : EfEntityRepositoryBase<Faaliyet, StrategyDBContext>, IFaaliyetDal
    {
        public new Faaliyet Get(Expression<Func<Faaliyet, bool>> filter = null)
        {
            using (StrategyDBContext context = new StrategyDBContext())
            {
                return context.Set<Faaliyet>().Include("Eylem").SingleOrDefault(filter);
            }
        }

        public new List<Faaliyet> GetAll(Expression<Func<Faaliyet, bool>> filter = null)
        {
            using (StrategyDBContext context = new StrategyDBContext())
            {
                return filter == null ? context.Set<Faaliyet>().Include("Eylem").ToList() : context.Set<Faaliyet>().Include("Eylem").Where(filter).ToList();
            }
        }
    }
}