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

namespace KavisWeb.Controllers
{
    public class KavisModul02Controller : KavisBaseController
    {
        private StratejikPlanManager2 _stratejikPlanManager;

        public KavisModul02Controller()
        {
            _stratejikPlanManager = new StratejikPlanManager2();
        }


        // GET: KavisModul02
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kurum
        public ActionResult Kurumlar()
        {
            KavisUser kavisUser = KavisHelper.GetUser();

            ViewBag.KavisUser = kavisUser;

            return View();

        }

        public JsonResult KurumStratejikPlanlar(int id)
        {

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            var liste = from x in manager.GetKurumSPList(id)
                        select new ListViewItem { Id = x.Id, Adi = x.Baslangic + "-" + x.Bitis };

            return Json(liste, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Birimler()
        {
            KavisUser kavisUser = KavisHelper.GetUser();

            if (kavisUser.KurumId > 0)
            {
                BirimManager manager = new BirimManager(new EfBirimDal());

                KurumManager kurumManager = new KurumManager();

                var kurum = kurumManager.Get(kavisUser.KurumId);

                if (kurum != null)
                {
                    var birimler = manager.GetAll(kavisUser.KurumId);

                    ViewBag.KurumAdi = kurum.Adi;
                    ViewBag.KurumId = kurum.Id;

                    return View(birimler);
                }

            }
            return View();
        }


       

        // GET: StratejikPlan
        public ActionResult StratejikPlanlar()
        {
            KavisUser kavisUser = KavisHelper.GetUser();

            var list = _stratejikPlanManager.GetViewListByUser(kavisUser);

            return View(list);

        }

        public ActionResult Eylemler()
        {
            return View();
        }

        public ActionResult StratejikPlanEdit(int id = 0)
        {
            KavisUser kavisUser = KavisHelper.GetUser();

            ViewBag.KavisUser = kavisUser;

            ViewBag.KurumAdi = kavisUser.KurumId;

            return View();
        }


        public JsonResult KurumlarListe()
        {

            KurumManager kurumManager = new KurumManager();

            var liste = kurumManager.GetList();

            var t = from x in liste
                    select new ListViewItem { Id = x.Id, Adi = x.Adi };

            return Json(t.ToList(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult PerformansProgrami(int id = 0, int yil = 0)
        {
            KavisUser kavisUser = KavisHelper.GetUser();

            if (kavisUser.KurumId > 0)
            {


                StratejikPlanManager2 manager = new StratejikPlanManager2();

                List<FaaliyetListView> faaliyetler = null;

                if (id > 0)
                    faaliyetler = manager.GetAllFaaliyetByBirim(id, yil);
                else
                    faaliyetler = manager.GetAllFaaliyet(yil);

                BirimManager birimManager = new BirimManager(new EfBirimDal());

                var sp = manager.GetAktifStratejikPlan(kavisUser.KurumId);

                if (sp != null)
                {
                    KavisHelper.YilListesiYukle(this, sp);
                }

                KavisHelper.BirimListesiYukle(this, KavisHelper.GetUser().KurumId);

                return View(faaliyetler);
            }

            return View();
        }


        public ActionResult FaaliyetRaporu(int id = 0, int yil = 0)
        {
            var kavisUser = KavisHelper.GetUser();

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            KurumManager kurumManager = new KurumManager();

            var kurum = kurumManager.Get(kavisUser.KurumId);

            if (kurum != null)
            {
                List<FaaliyetListView> faaliyetler = null;

                KavisHelper.BirimListesiYukle(this, kavisUser.KurumId);

                var sp = manager.GetAktifStratejikPlan(kavisUser.KurumId);

                KavisHelper.YilListesiYukle(this, sp);

                if (id > 0)
                    faaliyetler = manager.GetAllFaaliyetByBirim(id, yil == 0 ? kurum.AktifYil : yil);
                else
                    faaliyetler = manager.GetAllFaaliyet(yil == 0 ? kurum.AktifYil : yil);

                ViewBag.yil = kurum.AktifYil;

                return View(faaliyetler);
            }

            return HttpNotFound();

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
    }
}