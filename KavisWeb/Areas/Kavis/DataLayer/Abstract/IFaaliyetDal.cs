using Core.DataAccess;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.DataLayer.Abstract
{
    public interface IFaaliyetDal  : IEntityRepository<Faaliyet>
    {

    }
}