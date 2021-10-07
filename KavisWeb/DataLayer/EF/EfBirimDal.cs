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
    public class EfBirimDal : EfEntityRepositoryBase<Birim, StrategyDBContext>, IBirimDal
    {
        public new Birim Get(Expression<Func<Birim, bool>> filter = null)
        {
            using (StrategyDBContext context = new StrategyDBContext())
            {
                return context.Set<Birim>().Include("Kurum").SingleOrDefault(filter);
            }
        }
    }
}