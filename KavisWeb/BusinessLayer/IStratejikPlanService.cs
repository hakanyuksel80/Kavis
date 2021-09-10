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
        StratejikPlanItem Get(int id);

        List<StratejikPlanListView> GetViewList();

        void Update(StratejikPlan plan);

        void UpdateByItem(StratejikPlanItem model);

        void Delete(int id);
        
    }

    interface IPlanItem
    {

    }
}
