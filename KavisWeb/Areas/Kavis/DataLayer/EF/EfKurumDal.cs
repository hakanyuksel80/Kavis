using Core.DataAccess.EntityFramework;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.DataLayer.EF
{
    public class EfKurumDal : EfEntityRepositoryBase<Kurum, StrategyDBContext>, IKurumDal
    {
        
    }
}