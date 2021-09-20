using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KavisWeb.DataLayer
{

    public class StrategyDBContext : DbContext
    {
       
        public StrategyDBContext()
        {
            //this.Configuration.ProxyCreationEnabled = false;

            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<StratejikPlan> StratejikPlanlar { get; set; }

        public DbSet<Amac> Amaclar { get; set; }

        public DbSet<Hedef> Hedefler { get; set; }

        public DbSet<Strateji> Stratejiler { get; set; }

        public DbSet<Gosterge> Gostergeler { get; set; }

        public DbSet<Eylem> Eylemler { get; set; }
        

    }
}