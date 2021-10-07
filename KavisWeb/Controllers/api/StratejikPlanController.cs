using Core.Entities;
using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer;
using KavisWeb.Entities.DbModels;
using KavisWeb.Entities.DbModels;
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
            this.stratejikPlanManager = new StratejikPlanManager2();
        }

        // GET: api/StratejikPlan
        public List<KavisWeb.Entities.Views.StratejikPlanListView> Get()
        {
            return stratejikPlanManager.GetViewList();
        }

        // GET: api/StratejikPlan/5
        public StratejikPlan Get(int id)
        {
            var plan = this.stratejikPlanManager.GetPlan(id);
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
        private IResult Post222([FromBody] StratejikPlan model)
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

        public IResult Post([FromBody] StratejikPlan model)
        {

            try
            {
                var manager = this.stratejikPlanManager;

                var plan = manager.GetPlan(model.Id);

                if (plan == null)
                {
                    plan = new StratejikPlan();
                }

                //plan.KurumAdi = model.KurumAdi;
                //plan.KurumKodu = model.KurumKodu;
                //plan.KurumTipi = model.KurumTipi;
                plan.KurumId = model.KurumId;
                plan.Baslangic = model.Baslangic;
                plan.Bitis = model.Baslangic + 4;

                manager.SavePlan(plan);

                SaveItems(manager, model.Amaclar, plan);

                manager.SaveChanges();

                return new SuccessResult();


            }
            catch (Exception ex)
            {
                string mesaj = ex.Message;
                ErrorResult hata = new ErrorResult("Hata Oluştu:" + mesaj);

                return hata;

            }

        }

        private void SaveItems(IStratejikPlanService manager, List<Amac> amaclar, StratejikPlan plan)
        {
            if (amaclar == null) return;

            int siraNo = 0;
            foreach (var model in amaclar)
            {
                Amac amac = null;

                if (model.Id > 0)
                {
                    amac = manager.GetAmac(model.Id);
                    if (model.State == "deleted")
                    {
                        manager.DeleteAmac(amac);
                        continue;

                    }

                }
                else
                    amac = new Amac();


                amac.Baslik = model.Baslik;
                amac.SiraNo = ++siraNo;
                amac.Kod = siraNo.ToString();
                amac.StratejikPlan = plan;
                amac.StratejikPlanId = plan.Id;

                manager.SaveAmac(amac);

                SaveItems(manager, model.Hedefler, amac);


            }
        }

        private void SaveItems(IStratejikPlanService manager, List<Hedef> hedefler, Amac amac)
        {
            if (hedefler == null) return;

            // Hedefler
            int siraNo = 0;
            foreach (var model in hedefler)
            {
                Hedef hedef = new Hedef();

                if (model.Id > 0)
                {
                    hedef = manager.GetHedef(model.Id);
                    if (model.State == "deleted")
                    {
                        manager.DeleteHedef(hedef);
                        continue;
                    }

                }


                hedef.Amac = amac;
                hedef.SiraNo = ++siraNo;
                hedef.Kod = amac.SiraNo + "." + siraNo;
                hedef.Baslik = model.Baslik;

                manager.SaveHedef(hedef);

                SaveItems(manager, model.Gostergeler, hedef);
                SaveItems(manager, model.Stratejiler, hedef);

            }
        }

        private void SaveItems(IStratejikPlanService manager, List<Strateji> stratejiler, Hedef hedef)
        {
            if (stratejiler == null) return;
            int siraNo = 0;
            foreach (var model in stratejiler)
            {
                Strateji strateji = new Strateji();

                if (model.Id > 0)
                {
                    strateji = manager.GetStrateji(model.Id);
                    if (model.State == "deleted")
                    {
                        manager.DeleteStrateji(strateji);
                        continue;
                    }
                }

                strateji.Hedef = hedef;
                strateji.Baslik = model.Baslik;
                strateji.SiraNo = ++siraNo;
                strateji.Kod = hedef.Kod + "." + siraNo;


                manager.SaveStrateji(strateji);
            }
        }

        private void SaveItems(IStratejikPlanService manager, List<Gosterge> gostergeler, Hedef hedef)
        {
            if (gostergeler == null) return;
            int siraNo = 0;
            foreach (var model in gostergeler)
            {
                Gosterge gosterge = new Gosterge();

                if (model.Id > 0)
                {
                    gosterge = manager.GetGosterge(model.Id);
                    if (model.State == "deleted")
                    {
                        manager.DeleteGosterge(gosterge);
                        continue;
                    }
                }

                gosterge.Hedef = hedef;
                gosterge.Baslik = model.Baslik;
                gosterge.Kod = model.Kod;
                gosterge.Baslangic = model.Baslangic;
                gosterge.HedefeEtkisi = model.HedefeEtkisi;
                gosterge.SiraNo = ++siraNo;
                gosterge.Yil1 = model.Yil1;
                gosterge.Yil2 = model.Yil2;
                gosterge.Yil3 = model.Yil3;
                gosterge.Yil4 = model.Yil4;
                gosterge.Yil5 = model.Yil5;
                gosterge.Izleme = model.Izleme;
                gosterge.Rapor = model.Rapor;
                gosterge.SorumluBirimId = model.SorumluBirimId;
                gosterge.SorumluBirim = model.SorumluBirim;


                manager.SaveGosterge(gosterge);
            }
        }

        // DELETE: api/StratejikPlan/5
        public IResult Delete(int id)
        {
            try
            {
                if (stratejikPlanManager.DeletePlan(id))
                    return new SuccessResult();
                else
                    return new ErrorResult("Plan Silinemedi");

            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }


        }
    }

    //public abstract class SaveMyItems<T>
    //{
    //    private IStratejikPlanService manager;

    //    public SaveMyItems(IStratejikPlanService manager)
    //    {
    //        this.manager = manager;
    //    }

    //    public abstract void SaveItem<T>(StratejiTipi item, StratejiTipi parent);

    //    public class void SaveItems<T>(List<T>, )
    //}
}
