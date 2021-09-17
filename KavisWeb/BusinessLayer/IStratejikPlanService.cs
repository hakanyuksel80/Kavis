using KavisWeb.Enitites.DbModels;
using KavisWeb.Enitites.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KavisWeb.BusinessLayer
{
    public interface IStratejikPlanService
    {
        StratejikPlan Get(int id);

        List<StratejikPlanListView> GetViewList();

        void Add(StratejikPlan plan);

        void Update(StratejikPlan plan);        

        void Delete(int id);
        void SaveStratejikPlan(StratejikPlan plan);
        Amac GetAmac(int ıd);
        void DeleteAmac(Amac amac);
    }
}
