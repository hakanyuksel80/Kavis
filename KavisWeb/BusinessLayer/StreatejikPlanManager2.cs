using KavisWeb.DataLayer;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;
using KavisWeb.Enitites.DbModels;
using KavisWeb.Enitites.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class StratejikPlanManager2 : IStratejikPlanService
    {

        StrategyDBContext context = new StrategyDBContext();

        public StratejikPlanManager2()
        {

        }

        public List<StratejikPlanListView> GetViewList()
        {
            var plans = context.StratejikPlanlar.ToList();

            var list = from x in plans
                       select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.KurumAdi, Turu = Convert.ToInt32(x.KurumTipi) };

            return list.ToList();
        }

        public StratejikPlan GetPlan(int id)
        {
            if (id > 0)
            {
                var plan = context.StratejikPlanlar.Include("Amaclar").Include("Amaclar.Hedefler").Include("Amaclar.Hedefler.Gostergeler").Include("Amaclar.Hedefler.Stratejiler").SingleOrDefault(x => x.Id == id);

                return plan;
            }

            return null;
        }

        public void SavePlan(StratejikPlan plan)
        {
            if (plan.Id < 1)
                context.StratejikPlanlar.Add(plan);

            

        }

        public void DeletePlan(int id)
        {
            var plan = GetPlan(id);

            if (plan != null)
                context.StratejikPlanlar.Remove(plan);
        }

        public Amac GetAmac(int id)
        {
            return context.Amaclar.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteAmac(Amac amac)
        {
            context.Amaclar.Remove(amac);
        }

        public void SaveAmac(Amac amac)
        {
            if (amac.Id < 1)
                context.Amaclar.Add(amac);

            
        }


        public Hedef GetHedef(int id)
        {
            return context.Hedefler.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteHedef(Hedef hedef)
        {
            context.Hedefler.Remove(hedef);
        }

        public void SaveHedef(Hedef hedef)
        {
            if (hedef.Id < 1)
                context.Hedefler.Add(hedef);
 

        }


        public Strateji GetStrateji(int id)
        {
            return context.Stratejiler.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteStrateji(Strateji strateji)
        {
            context.Stratejiler.Remove(strateji);
        }

        public void SaveStrateji(Strateji strateji)
        {
            if (strateji.Id < 1)
                context.Stratejiler.Add(strateji);

            
        }


        public Gosterge GetGosterge(int id)
        {
            return context.Gostergeler.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteGosterge(Gosterge gosterge)
        {
            context.Gostergeler.Remove(gosterge);
        }

        public void SaveGosterge(Gosterge gosterge)
        {
            if (gosterge.Id < 1)
                context.Gostergeler.Add(gosterge);

           
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public List<Strateji> GetAllStrateji(int planId)
        {
            return context.Stratejiler.Where(x => x.Hedef.Amac.StratejikPlanId == planId).ToList();
        }        

        public List<Eylem> GetListEylemByStrateji(int id)
        {
            return context.Eylemler.Where(x => x.StratejiId == id).ToList();
        }

        public Eylem GetEylem(int id)
        {
            return context.Eylemler.SingleOrDefault(x => x.Id == id);
        }
    }
}