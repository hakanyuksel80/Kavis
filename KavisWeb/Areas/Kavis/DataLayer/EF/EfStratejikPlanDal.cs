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
    public class EfStratejikPlanDal : EfEntityRepositoryBase<StratejikPlan, StrategyDBContext>, IStratejikPlanDal
    {
        

        public new StratejikPlan Get(Expression<Func<StratejikPlan, bool>> filter)
        {
            using (StrategyDBContext context = new StrategyDBContext())
            {
                return context.StratejikPlanlar.Include("Amaclar").Include("Amaclar.Hedefler").Include("Amaclar.Hedefler.Gostergeler").Include("Amaclar.Hedefler.Stratejiler").SingleOrDefault(filter);
            }
        }
    }
}