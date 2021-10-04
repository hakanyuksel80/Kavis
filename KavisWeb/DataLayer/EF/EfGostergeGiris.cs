using Core.DataAccess.EntityFramework;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.DataLayer.EF
{
    public class EfGostergeGirisDal : EfEntityRepositoryBase<GostergeGiris, StrategyDBContext>, IGostergeGirisDal
    {

    }
}