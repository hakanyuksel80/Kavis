using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.DbModels;
using KavisWeb.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FaaliyetRaporu()
        {

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            List<FaaliyetListView> model = manager.GetFaaliyetRapor();

            return View(model);
        }


        public ActionResult Gostergeler()
        {
            var kavisUser = KavisHelper.GetUser();

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            BirimManager birimManager = new BirimManager(new EfBirimDal());

            if (kavisUser.Type == Entities.KavisUserType.Kurum)
            {
                if (kavisUser.KurumId > 0)
                {
                    StratejikPlan stratejikPlan = manager.GetAktifStratejikPlan(kavisUser.KurumId);

                    if (stratejikPlan != null)
                    {
                        GostergeGirisManager girisManager = new GostergeGirisManager(new EfGostergeGirisDal());

                        foreach (var amac in stratejikPlan.Amaclar)
                        {
                            foreach (var hedef in amac.Hedefler)
                            {
                                var eskiGostergeList = hedef.Gostergeler.ToList();
                                hedef.Gostergeler = new List<Gosterge>();

                                foreach (var aGosterge in eskiGostergeList)
                                {
                                    if (!string.IsNullOrEmpty(aGosterge.SorumluBirimId))
                                    {
                                        string[] birimIds = aGosterge.SorumluBirimId.Split(',');

                                        foreach (var aBirimId in birimIds)
                                        {

                                            var birim = birimManager.Get(Convert.ToInt32(aBirimId));

                                            Gosterge gos = new Gosterge()
                                            {
                                                Baslangic = aGosterge.Baslangic,
                                                Baslik = aGosterge.Baslik,
                                                HedefeEtkisi = aGosterge.HedefeEtkisi,
                                                Id = aGosterge.Id,
                                                Izleme = aGosterge.Izleme,
                                                Kod = aGosterge.Kod,
                                                Rapor = aGosterge.Rapor,
                                                SiraNo = aGosterge.SiraNo,
                                                SorumluBirim = birim.Baslik,
                                                Yil1 = aGosterge.Yil1,
                                                Yil1G = "",// aGosterge.Yil2,
                                                Yil2 = aGosterge.Yil2,
                                                Yil2G = "",//aGosterge.Yil2G,
                                                Yil3 = aGosterge.Yil3,
                                                Yil3G = aGosterge.Yil3G,
                                                Yil4 = aGosterge.Yil4,
                                                Yil4G = "",//aGosterge.Yil4G,
                                                Yil5 = aGosterge.Yil5,
                                                Yil5G = "",//aGosterge.Yil5G,
                                                
                                            };

                                            for (byte i = 1; i <= 5; i++)
                                            {
                                                var giris = girisManager.GetByBirim(Convert.ToInt32(aBirimId), aGosterge.Id, i);
                                                if (giris != null)
                                                    gos.SetGerceklesenDeger(giris.Yil, giris.Deger);
                                                
                                            }                                            

                                            hedef.Gostergeler.Add(gos);
                                        }
                                    }

                                    // Burada birimin girdiği değerler varsa onu gösterelerim. Yoksa boş girelim, girilen değeri göremesin

                                }
                            }

                            amac.Hedefler = amac.Hedefler.Where(x => x.Gostergeler.Count() > 0).ToList();
                        }

                        stratejikPlan.Amaclar = stratejikPlan.Amaclar.Where(x => x.Hedefler.Count() > 0).ToList();

                        return View(stratejikPlan);
                    }

                }
                else
                    ViewBag.Hata = "Kurum kaydı bulunamadı";

            }

            return View();
        }

        public PartialViewResult UserMenu()
        {
            var kavisUser = KavisHelper.GetUser();
            return PartialView(kavisUser);
        }

    }
}