using KavisWeb.DataLayer;
using KavisWeb.DataLayer.Abstract;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using KavisWeb.Entities.Views;
using KavisWeb.Entities;

namespace KavisWeb.BusinessLayer
{
    public class StratejikPlanManager2
    {

        StrategyDBContext context = new StrategyDBContext();

        public StratejikPlanManager2()
        {

        }

        public List<StratejikPlanListView> GetViewList()
        {
            var plans = context.StratejikPlanlar.ToList();

            var list = from x in plans
                       select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.Kurum.Adi, Turu = x.Kurum.Turu.ToString() };

            return list.ToList();

        }

        //public List<StratejikPlanListView> GetViewListByKurum(int kurumId)
        //{
        //    var plans = context.StratejikPlanlar.Where(x => x.KurumId == kurumId).ToList();

        //    var list = from x in plans
        //               select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.Kurum.Adi, Turu = x.Kurum.Turu.ToString() };

        //    return list.ToList();

        //}

        public List<StratejikPlanListView> GetViewListByUser(KavisUser user)
        {
            if (user.Type == KavisUserType.Admin)
            {
                var plans = context.StratejikPlanlar.ToList();

                var list = from x in plans
                           select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.Kurum.Adi, Turu = x.Kurum.Turu.ToString() };

                return list.ToList();
            }
            else if (user.Type == KavisUserType.Kurum)
            {
                if (user.KurumId > 0)
                {
                    var plans = context.StratejikPlanlar.Where(x => x.KurumId == user.KurumId).ToList();

                    var list = from x in plans
                               select new StratejikPlanListView() { Id = x.Id, Donem = x.Baslangic.ToString() + " " + x.Bitis.ToString(), Kurum = x.Kurum.Adi, Turu = x.Kurum.Turu.ToString() };

                    return list.ToList();
                }                
            }

            return new List<StratejikPlanListView>();


        }

        public List<StratejikPlan> GetKurumSPList(int kurumId)
        {
            return context.StratejikPlanlar.Where(x => x.KurumId == kurumId).ToList();
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

        public bool DeletePlan(int id)
        {
            var plan = GetPlan(id);

            if (plan != null)
                context.StratejikPlanlar.Remove(plan);

            return context.SaveChanges() > 0;
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

        public Faaliyet GetFaaliyet(int id)
        {
            return context.Faaliyetler.SingleOrDefault(x => x.Id == id);
        }

        public void AddFaaliyet(Faaliyet faaliyet)
        {
            context.Faaliyetler.Add(faaliyet);
        }

        public List<Strateji> GetAllStratejiByBirim(int birim = 0)
        {
            List<Strateji> liste = new List<Strateji>();

            var stratejiler = context.Stratejiler.Include("Eylemler").ToList();

            foreach (var strateji in stratejiler)
            {
                if (strateji.Eylemler != null)
                {
                    foreach (var eylem in strateji.Eylemler)
                    {
                        if (!String.IsNullOrEmpty(eylem.Birim))
                        {
                            string[] birims = eylem.Birim.Split(',');

                            if (birims.Contains(birim.ToString()))
                            {
                                liste.Add(strateji);
                                break;
                            }
                        }
                    }
                }
            }

            return liste;
        }

        public List<FaaliyetListView> GetAllFaaliyet(int yil = 0)
        {
            var faaliyetler = context.Faaliyetler.Include("Eylem").Select(x => x).ToList();

            if (yil > 0)
            {
                faaliyetler = faaliyetler.Where(x => x.Yil == yil).ToList();
            }

            faaliyetler = faaliyetler.OrderBy(x => x.Eylem.Kod).ThenBy(x => x.SiraNo).ToList();

            return (from x in faaliyetler
                    join y in context.Birimler on x.Birim equals y.Id
                    select new FaaliyetListView()
                    {
                        Id = x.Id,
                        EylemAdi = x.Eylem.Kod + " " + x.Eylem.Baslik,
                        FaaliyetAdi = x.Baslik,
                        Birim = y.Baslik,
                        Durum = x.Durum
                    }).ToList();
        }





        public List<FaaliyetListView> GetAllFaaliyetByBirim(int birim, int yil)
        {
            var faaliyetler = context.Faaliyetler.Include("Eylem").Where(x => x.Birim == birim && x.Yil == yil);

            return (from x in faaliyetler
                    join y in context.Birimler on x.Birim equals y.Id
                    select new FaaliyetListView() { Id = x.Id, EylemAdi = x.Eylem.Kod + " " + x.Eylem.Baslik, FaaliyetAdi = x.Baslik, Birim = y.Baslik, Baslama = x.Baslama, Bitis = x.Bitis, Gerceklesme = x.Gerceklesme, Sonuc = x.Sonuc, Durum = x.Durum }).ToList();
        }


        //public List<FaaliyetListView> GetFaaliyetRapor()
        //{
        //    var faaliyetler = context.Faaliyetler.Include("Eylem").OrderBy(x => x.Eylem.Kod).ThenBy(x => x.SiraNo).ToList();

        //    return (from x in faaliyetler
        //            select new FaaliyetListView() { Id = x.Id, EylemAdi = x.Eylem.Kod + " " + x.Eylem.Baslik, FaaliyetAdi = x.Baslik, Birim = x.BirimAdi, Gerceklesme = x.Gerceklesme, Durum = x.Durum, Sonuc = x.Sonuc, Baslama = x.Baslama, Bitis = x.Bitis }).ToList();
        //}

        public void DeleteEylem(Eylem eylem)
        {
            context.Eylemler.Remove(eylem);
        }

        public void AddEylem(Eylem eylem)
        {
            context.Eylemler.Add(eylem);
        }

        public void DeleteFaaliyet(Faaliyet faaliyet)
        {
            context.Faaliyetler.Remove(faaliyet);
        }

        public StratejikPlan GetAktifStratejikPlan(int kurumId)
        {
            StratejikPlan plan = GetPlan(1);

            return plan;
        }




    }
}