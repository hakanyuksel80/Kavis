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
    public class StratejikPlanManager 
    {
        public static StratejikPlanItem SP_Data = new StratejikPlanItem()
        {
            Id = 1,
            SiraNo = 1,
            Baslik = "BURSA İL MİLLİ EĞİTİM MÜDÜRLÜĞÜ 2019-2024 Stratejik Planı",
            DonemBaslangici = 2019,
            SPTuru = "İL",
            Amaclar = new List<AmacItem>()
                {
                    new AmacItem { Id = 1, Baslik = "AMACIM 1", SiraNo = 1 ,
                        Hedefler = new List<HedefItem>() {
                        new HedefItem() {Id = 3, Baslik = "HEDEFİM 1.1", SiraNo = 1,
                            Gostergeler = new List<GostergeItem>() {
                         new GostergeItem() {
                             Id = 4 , SiraNo = 1, Baslangic = "12", HedefeEtkisi = "50", Baslik = "Postttt", Yil1 = "3" , Yil2 = "4", Yil3 = "5", Yil4 = "6", Yil5 ="9",
                         }
                            },
                            Stratejiler = new List<PlanItem>() {

                                 new PlanItem() { Baslik = "Ebesi", SiraNo = 1, Id = 5 },

                            }

                        },
                    } },
                    new AmacItem { Id = 2, Baslik = "AMACIM 2", SiraNo = 2},

                }
        };

        private IStratejikPlanDal _planDal;

        private IStrategyItemDal<Amac> _AmacDal;

        private IStrategyItemDal<Hedef> _HedefDal;

        private IStrategyItemDal<Gosterge> _GostergeDal;

        private IStrategyItemDal<Strateji> _StratejiDal;

        public StratejikPlanManager()
        {
            _planDal = new EfStratejikPlanDal();

            _AmacDal = new EfAmacDal();

            _HedefDal = new EfHedefDal();

            _GostergeDal = new EfGostergeDal();

            _StratejiDal = new EfStratejiDal();
        }

        public List<StratejikPlanListView> GetViewList()
        {
            var plans = _planDal.GetAll();

            var list = from x in plans
                       select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.KurumAdi, Turu = Convert.ToInt32(x.KurumTipi) };

            return list.ToList();
        }
             
        public StratejikPlan GetPlan(int id)
        {
            if (id > 0)
            {
                var plan = _planDal.Get(x => x.Id == id);

                return plan;
            }

            return new StratejikPlan();
        }

        public void SavePlan(StratejikPlan plan)
        {
            if (plan.Id > 0)
                _planDal.Update(plan);
            else
                _planDal.Add(plan);
        }

        public void DeletePlan(int id)
        {
            var plan = GetPlan(id);

            if (plan != null)
                _planDal.Delete(plan);

        }


        public Amac GetAmac(int id)
        {
            return _AmacDal.Get(x => x.Id == id);
        }

        public void DeleteAmac(Amac amac)
        {
            _AmacDal.Delete(amac);
        }
            
        public void SaveAmac(Amac amac)
        {
            if (amac.Id > 0)
                _AmacDal.Update(amac);
            else
                _AmacDal.Add(amac);
        }

        public Hedef GetHedef(int id)
        {
            return _HedefDal.Get(x => x.Id == id);
        }

        public void DeleteHedef(Hedef hedef)
        {
            _HedefDal.Delete(hedef);
        }

        public void SaveHedef(Hedef hedef)
        {
            if (hedef.Id > 0)
                _HedefDal.Update(hedef);
            else
                _HedefDal.Add(hedef);
        }

        public Strateji GetStrateji(int id)
        {
            return _StratejiDal.Get(x => x.Id == id);
        }

        public void DeleteStrateji(Strateji strateji)
        {
            _StratejiDal.Delete(strateji);
        }

        public void SaveStrateji(Strateji strateji)
        {
            if (strateji.Id > 0)
                _StratejiDal.Update(strateji);
            else
                _StratejiDal.Add(strateji);
        }

        public Gosterge GetGosterge(int id)
        {
            return _GostergeDal.Get(x => x.Id == id);
        }

        public void DeleteGosterge(Gosterge gosterge)
        {
            _GostergeDal.Delete(gosterge);
        }

        public void SaveGosterge(Gosterge gosterge)
        {
            if (gosterge.Id > 0)
                _GostergeDal.Update(gosterge);
            else
                _GostergeDal.Add(gosterge);
        }

        public void SaveChanges()
        {
           
        }

        public List<Strateji> GetAllStrateji(int planId)
        {
            throw new NotImplementedException();
        }

        public List<Eylem> GetListEylemByStrateji(int id)
        {
            throw new NotImplementedException();
        }

        public Eylem GetEylem(int id)
        {
            throw new NotImplementedException();
        }
    }
}