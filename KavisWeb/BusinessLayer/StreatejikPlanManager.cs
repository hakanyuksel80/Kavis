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
    public class StratejikPlanManager : IStratejikPlanService
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

        private IStrategyItemDal _planItemDal;

        public StratejikPlanManager()
        {
            _planDal = new EfStratejikPlanDal();

            _planItemDal = new EfStrategyItemDal();
        }

        public List<StratejikPlanListView> GetViewList()
        {
            var plans = _planDal.GetAll();

            var list = from x in plans
                       select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.KurumAdi, Turu = Convert.ToInt32(x.KurumTipi) };

            return list.ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StratejikPlan Get(int id)
        {
            if (id > 0)
            {
                var plan = _planDal.Get(x => x.Id == id);              

                return plan;
            }
            return new StratejikPlan();

        }

        public void Update(StratejikPlan plan)
        {
            _planDal.Update(plan);
        }

        public void Add(StratejikPlan plan)
        {
            throw new NotImplementedException();
        }

        public void SaveStratejikPlan(StratejikPlan plan)
        {
            throw new NotImplementedException();
        }

        public Amac GetAmac(int ıd)
        {
            throw new NotImplementedException();
        }

        public void DeleteAmac(Amac amac)
        {
            throw new NotImplementedException();
        }
    }
}