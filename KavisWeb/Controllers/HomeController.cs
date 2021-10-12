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

        private ViewGostergeGirisModel BirimGostergeYukle(int birimId)
        {
            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var birim = birimManager.Get(birimId);

            if (birim != null && birim.Kurum != null)
            {
                if (birim.Kurum.AktifPlanId > 0)
                {



                    GostergeGirisManager girisManager = new GostergeGirisManager(new EfGostergeGirisDal());



                    if (stratejikPlan != null)
                    {
                        foreach (var amac in stratejikPlan.Amaclar)
                        {
                            foreach (var hedef in amac.Hedefler)
                            {
                                hedef.Gostergeler = hedef.Gostergeler.Where(x => x.SorumluBirimId == birim.Id).ToList();

                                foreach (var aGosterge in hedef.Gostergeler)
                                {
                                    // Burada birimin girdiği değerler varsa onu gösterelerim. Yoksa boş girelim, girilen değeri göremesin
                                    var giris = girisManager.GetByBirim(birimId, aGosterge.Id, (byte)birim.Kurum.AktifYil);
                                    if (giris != null)
                                        aGosterge.SetGerceklesenDeger(giris.Yil, giris.Deger);
                                    else
                                        aGosterge.SetGerceklesenDeger((byte)birim.Kurum.AktifYil, "");
                                }
                            }

                            amac.Hedefler = amac.Hedefler.Where(x => x.Gostergeler.Count() > 0).ToList();
                        }

                        stratejikPlan.Amaclar = stratejikPlan.Amaclar.Where(x => x.Hedefler.Count() > 0).ToList();

                    }



                    return model;



                }
            }
            else
            {
                ViewBag.Hata = "Biriminizin kaydı bulunamadı!.";
            }

            return new ViewGostergeGirisModel();
        }






        public ActionResult Gostergeler()
        {
            var kavisUser = KavisHelper.GetUser();

            StratejikPlanManager2 manager = new StratejikPlanManager2();



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
                                    string[] birimIds = aGosterge.SorumluBirim.Split(',');

                                    foreach (var aBirimId in birimIds)
                                    {
                                        
                                        for (byte i = 1; i <= 5; i++)
                                        {
                                            var giris = girisManager.GetByBirim(aBirimId, aGosterge.Id, i);
                                            if (giris != null)
                                                aGosterge.SetGerceklesenDeger(giris.Yil, giris.Deger);
                                            else
                                                aGosterge.SetGerceklesenDeger((byte)birim.Kurum.AktifYil, "");
                                        }
                                       
                                    }

                                    // Burada birimin girdiği değerler varsa onu gösterelerim. Yoksa boş girelim, girilen değeri göremesin

                                }
                            }

                            amac.Hedefler = amac.Hedefler.Where(x => x.Gostergeler.Count() > 0).ToList();
                        }

                        stratejikPlan.Amaclar = stratejikPlan.Amaclar.Where(x => x.Hedefler.Count() > 0).ToList();

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