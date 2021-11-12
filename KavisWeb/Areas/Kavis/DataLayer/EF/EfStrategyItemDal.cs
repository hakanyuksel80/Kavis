using Core.DataAccess.EntityFramework;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.DataLayer.EF
{
    public class EfAmacDal : EfEntityRepositoryBase<Amac, StrategyDBContext>, IStrategyItemDal<Amac>
    {

    }

    public class EfHedefDal : EfEntityRepositoryBase<Hedef, StrategyDBContext>, IStrategyItemDal<Hedef>
    {

    }

    public class EfGostergeDal : EfEntityRepositoryBase<Gosterge, StrategyDBContext>, IStrategyItemDal<Gosterge>
    {

    }

    public class EfStratejiDal : EfEntityRepositoryBase<Strateji, StrategyDBContext>, IStrategyItemDal<Strateji>
    {

    }
}