using KavisWeb.BusinessLayer;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KavisWeb.Controllers.api
{
    public class StratejikPlanController : ApiController
    {
        IStratejikPlanService stratejikPlanManager = null;

        public StratejikPlanController()
        {
            this.stratejikPlanManager = new StratejikPlanManager();
        }        

        // GET: api/StratejikPlan
        public List<KavisWeb.Enitites.Views.StratejikPlanListView> Get()
        {
            return stratejikPlanManager.GetViewList();
        }

        // GET: api/StratejikPlan/5
        public StratejikPlanItem Get(int id)
        {
            return this.stratejikPlanManager.Get(id);
        }

        // POST: api/StratejikPlan
        public void Post([FromBody] StratejikPlanItem model)
        {
            stratejikPlanManager.UpdateByItem(model);
        }       

        // DELETE: api/StratejikPlan/5
        public void Delete(int id)
        {
            stratejikPlanManager.Delete(id);
        }
    }
}
