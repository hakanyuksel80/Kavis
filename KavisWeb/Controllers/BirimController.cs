using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Enitites;
using KavisWeb.Enitites.DbModels;
using KavisWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class BirimController : Controller
    {
        IStratejikPlanService manager;

        int birimId = 0;

        byte aktifYil = 2;

        public BirimController()
        {
            this.manager = new StratejikPlanManager2();
        }

        // GET: Birim
        public ActionResult Index()
        {

            KavisUser kavisUser = KavisHelper.GetUser();


            if (kavisUser.Type == KavisUserType.Birim)
            {
                if (kavisUser.BirimId > 0)
                {
                    //Kullanıcını kurumunu bul

                    //Kullanıcının birimini bul

                    //Kurumun SP'sini al
                    BirimManager birimManager = new BirimManager(new EfBirimDal());

                    var birim = birimManager.Get(kavisUser.BirimId);

                    if (birim != null && birim.Kurum != null)
                    {
                        if (birim.Kurum.AktifPlanId > 0)
                        {
                            StratejikPlanManager2 stratejikPlanManager = new StratejikPlanManager2();
                            if (birim.KurumId != null)
                            {
                                var plan = stratejikPlanManager.GetAktifStratejikPlan(birim.KurumId??0);

                                if (plan != null)
                                {
                                    var stratejiler = manager.GetAllStratejiByBirim(birim.Id);

                                    var faaliyetler = manager.GetAllFaaliyetByBirim(birim.Id);
                                    
                                    ViewPerformansGirisModel model = new ViewPerformansGirisModel()
                                    {
                                        Stratejiler = stratejiler,
                                        Faaliyetler = faaliyetler,
                                    };

                                    ViewBag.seciliBirimId = birim.Id;

                                    return View(model);
                                }
                                else
                                    ViewBag.Hata = "Kurumunuzun stratejik planı bulunamadı";

                            }
                            
                        }
                        else
                            ViewBag.Hata = "Kurumunuzun stratejik planı seçilmedi";
                    }
                    else
                    {
                        ViewBag.Hata = "Kurumunuzun kaydı bulunamadı!.";
                    }

                }
                else
                {
                    ViewBag.Hata = "Biriminizin kaydı bulunamadı!.";
                }
            }


            BirimListesiYukle();

            return View();

        }

        public ActionResult Gosterge(int id = 0)
        {

            birimId = id;

            aktifYil = 2;

            ViewBag.AktifYil = aktifYil;

            BirimListesiYukle();

            GostergeGirisManager girisManager = new GostergeGirisManager(new EfGostergeGirisDal());

            if (birimId > 0)
            {
                StratejikPlan stratejikPlan = this.manager.GetAktifStratejikPlan(1);

                if (stratejikPlan != null)
                {


                    foreach (var amac in stratejikPlan.Amaclar)
                    {
                        foreach (var hedef in amac.Hedefler)
                        {
                            hedef.Gostergeler = hedef.Gostergeler.Where(x => x.SorumluBirimId == id).ToList();

                            foreach (var aGosterge in hedef.Gostergeler)
                            {
                                // Burada birimin girdiği değerler varsa onu gösterelerim. Yoksa boş girelim, girilen değeri göremesin
                                var giris = girisManager.GetByBirim(birimId, aGosterge.Id, aktifYil);
                                if (giris != null)
                                    aGosterge.SetGerceklesenDeger(giris.Yil, giris.Deger);
                                else
                                    aGosterge.SetGerceklesenDeger(aktifYil, "");

                            }
                        }

                        amac.Hedefler = amac.Hedefler.Where(x => x.Gostergeler.Count() > 0).ToList();
                    }

                    stratejikPlan.Amaclar = stratejikPlan.Amaclar.Where(x => x.Hedefler.Count() > 0).ToList();

                }
                return View(stratejikPlan);

            }

            return View(new StratejikPlan());
        }

        private void BirimListesiYukle()
        {
            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var birimler = birimManager.GetAll();

            List<SelectListItem> birimSelectList = (from x in birimler select new SelectListItem { Value = x.Id.ToString(), Text = x.Baslik }).ToList();


            ViewBag.BirimSelectList = birimSelectList;
        }
    }
}