using Core.Entities;
using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

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
        public StratejikPlan Get(int id)
        {
            var plan = this.stratejikPlanManager.Get(id);
            return plan;
        }

        private bool linkToContext<T>(StrategyDBContext context, T obj) where T : IEntity, IStratejiTipi
        {
            if (obj.State == "deleted")
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                return false;
            }

            if (obj.Id > 0)
                context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            else
                context.Entry(obj).State = System.Data.Entity.EntityState.Added;

            return true;
        }

        // POST: api/StratejikPlan      
        public IResult Post([FromBody] StratejikPlan model)
        {
            try
            {
                StrategyDBContext context = new StrategyDBContext();

                if (model.Amaclar != null)
                    foreach (var amac in model.Amaclar)
                    {

                        
                       



                        if (amac.Hedefler != null)
                        {
                            int i = 0;
                            while (i < amac.Hedefler.Count())
                            {
                                var hedef = amac.Hedefler[i];
                                

                                if (hedef.Gostergeler != null)
                                {
                                    var j = 0;

                                    while (j < hedef.Gostergeler.Count())
                                    {
                                        var gosterge = hedef.Gostergeler[j];
                                        if (linkToContext(context, gosterge)) j++;
                                    }
                                }

                                if (hedef.Stratejiler != null)
                                {
                                    var j = 0;

                                    while (j < hedef.Stratejiler.Count())
                                    {
                                        var strateji = hedef.Stratejiler[j];
                                        if (linkToContext(context, strateji)) j++;
                                    }
                                }

                                if (linkToContext(context, hedef)) i++;
                            }
                        }

                        linkToContext(context, amac);
                        amac.StratejikPlan = model;
                        amac.StratejikPlanId = model.Id;

                    }
                

                if (model.Id <= 0)
                    context.Entry<StratejikPlan>(model).State = System.Data.Entity.EntityState.Added;
                else
                    context.Entry<StratejikPlan>(model).State = System.Data.Entity.EntityState.Modified;

                int affectedRecords = context.SaveChanges();
                if (affectedRecords > 0)
                    return new SuccessResult();
                else
                    return new ErrorResult("Kayıt edilemedi.");

            }
            catch (Exception ex)
            {
                string mesaj = ex.Message;
                ErrorResult hata = new ErrorResult("Hata Oluştu:" + mesaj);

                return hata;

            }
        }

        //public void Post2([FromBody] StratejikPlan model)
        //{
        //    var manager = this.stratejikPlanManager;

        //    var plan = manager.Get(model.Id);

        //    if (plan == null)
        //    {
        //        plan = new StratejikPlan();
        //    }

        //    plan.KurumAdi = model.KurumAdi;
        //    plan.KurumKodu = model.KurumKodu;
        //    plan.KurumTipi = model.KurumTipi;
        //    plan.Baslangic = model.Baslangic;
        //    plan.Bitis = model.Baslangic + 4;

        //    manager.SaveStratejikPlan(plan);

        //    foreach (var modelAmac in model.Amaclar)
        //    {
        //        Amac amac = null;

        //        if (modelAmac.Id > 0)
        //            amac = manager.GetAmac(amac.Id);
        //        else
        //            amac = new Amac();

        //        if (modelAmac.State == "deleted")
        //            manager.DeleteAmac(amac);
        //        else
        //        {
        //            amac.Baslik = modelAmac.Baslik;
        //            amac.Kod = "";
        //            amac.
        //        }


        //    }




        //}

        // DELETE: api/StratejikPlan/5
        public void Delete(int id)
        {
            stratejikPlanManager.Delete(id);
        }
    }
}
