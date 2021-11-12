using Core.DataAccess;
using Core.Entities;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KavisWeb.DataLayer.Abstract
{
    public interface IStrategyItemDal<T> : IEntityRepository<T> where T : StratejiTipi, IEntity, new()
    {

    }
}
