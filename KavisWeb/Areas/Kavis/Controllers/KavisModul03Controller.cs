using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities;
using KavisWeb.Entities.DbModels;
using KavisWeb.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Areas.Kavis.Controllers
{    
    [SessionState(System.Web.SessionState.SessionStateBehavior.Required)]
    public class KavisModul03Controller : KavisBaseController
    {
        StratejikPlanManager manager;

        public KavisModul03Controller()
        {
            this.manager = new StratejikPlanManager();
        }

        // GET: KavisModul03
        public ActionResult Index()
        {
            KavisUser kavisUser = kavisHelper.GetUser();

            KurumManager kurumManager = new KurumManager();

            var kurum = kurumManager.Get(kavisUser.KurumId);

            if (kurum != null)
            {
                ViewBag.Mesaj = kurum.Mesaj;
            }
            

            return View();
        }

        // GET: Birim Faaliyet Listesi
        public ActionResult Faaliyetler(int id = 0)
        {
            KavisUser kavisUser =kavisHelper.GetUser();

            if (kavisUser.Type == KavisUserType.Birim)
            {
                if (kavisUser.BirimId > 0)
                {
                    //Kullanıcını kurumunu bul

                    //Kullanıcının birimini bul

                    //Kurumun SP'sini al

                    StratejikPlan stratejikPlan = this.manager.GetAktifStratejikPlan(kavisUser.BirimId);

                    var model = BirimFaaliyetYukle(kavisUser.BirimId);

                    return View(model);

                }
                else
                {
                    ViewBag.Hata = "Biriminizin kaydı bulunamadı!.";
                }
            }
            else if (kavisUser.Type == KavisUserType.Kurum)
            {
                // Kurum aktif sp'sine göre birim seçerek girebilir

                kavisHelper.BirimListesiYukle(this, kavisUser.KurumId);

                ViewBag.BirimListesiGoster = true;

                if (id > 0)
                {
                    var model = BirimFaaliyetYukle(kavisUser.BirimId);

                    return View(model);
                }

            }




            return View(new ViewPerformansGirisModel());

        }

        public ActionResult Gostergeler(int id = 0)
        {
            KavisUser kavisUser = kavisHelper.GetUser();

            if (kavisUser.Type == KavisUserType.Birim)
            {
                ViewBag.BirimListesiGoster = false;

                if (kavisUser.BirimId > 0)
                {
                    var model = BirimGostergeYukle(kavisUser.BirimId);

                    return View(model);
                }
                else
                {
                    ViewBag.Hata = "Biriminizin kaydı bulunamadı!.";
                }
            }
            else if (kavisUser.Type == KavisUserType.Kurum)
            {
                // Kurum aktif sp'sine göre birim seçerek girebilir

                ViewBag.BirimListesiGoster = true;

                kavisHelper.BirimListesiYukle(this, kavisUser.KurumId);

                if (id > 0)
                {
                    var model = BirimGostergeYukle(id);

                    return View(model);
                }

            }



            return View(new ViewGostergeGirisModel());
        }

        public ViewPerformansGirisModel BirimFaaliyetYukle(int birimId)
        {
            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var birim = birimManager.Get(birimId);

            if (birim != null && birim.Kurum != null)
            {
                if (birim.Kurum.AktifPlanId > 0)
                {
                    StratejikPlanManager stratejikPlanManager = new StratejikPlanManager();

                    if (birim.KurumId != null)
                    {
                        var plan = stratejikPlanManager.GetAktifStratejikPlan(birim.KurumId ?? 0);

                        if (plan != null)
                        {
                            var stratejiler = manager.GetAllStratejiByBirim(birim.Id);

                            var faaliyetler = manager.GetAllFaaliyetByBirim(birim.Id, birim.Kurum.AktifPlanId ?? 0);

                            ViewPerformansGirisModel model = new ViewPerformansGirisModel()
                            {
                                Stratejiler = stratejiler,
                                Faaliyetler = faaliyetler,
                                Birim = birim,
                            };

                            //ViewBag.seciliBirimId = birim.Id;

                            ViewBag.AktifYil = birim.Kurum.AktifYil;

                            return model;
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

            //Boş döndür
            return new ViewPerformansGirisModel();
        }

        //Seçili birime aktif stratjik plan ve yılına göre atanmış göstergeleri ve girdiği gerçekleşme değerleri gösterilir 
        private ViewGostergeGirisModel BirimGostergeYukle(int birimId)
        {
            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var birim = birimManager.Get(birimId);

            if (birim != null && birim.Kurum != null)
            {
                if (birim.Kurum.AktifPlanId > 0)
                {

                    ViewBag.AktifYil = birim.Kurum.AktifYil;

                    kavisHelper.BirimListesiYukle(this, birim.Kurum.Id);

                    GostergeGirisManager girisManager = new GostergeGirisManager(new EfGostergeGirisDal());

                    StratejikPlan stratejikPlan = this.manager.GetAktifStratejikPlan(birim.KurumId ?? 0);

                    if (stratejikPlan != null)
                    {
                        foreach (var amac in stratejikPlan.Amaclar)
                        {
                            foreach (var hedef in amac.Hedefler)
                            {

                                hedef.Gostergeler = hedef.Gostergeler.Where(x => x.SorumluBirimId != null && x.SorumluBirimId.Split(',').ToList().Contains(birim.Id.ToString())).ToList();
                                //hedef.Gostergeler = hedef.Gostergeler.Where(x => x.SorumluBirimId.Split(',').ToList().Contains(birim.Id.ToString())).ToList();

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

                    ViewGostergeGirisModel model = new ViewGostergeGirisModel
                    {
                        Plan = stratejikPlan,
                        Birim = birim,
                    };

                    return model;



                }
            }
            else
            {
                ViewBag.Hata = "Biriminizin kaydı bulunamadı!.";
            }

            return new ViewGostergeGirisModel();
        }
    }
}