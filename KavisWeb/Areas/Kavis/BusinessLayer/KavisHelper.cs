using KavisWeb.DataLayer.EF;
using KavisWeb.Entities;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KavisWeb.BusinessLayer
{

    public interface IKavisHelper
    {
        KavisUser GetUser();

        void BirimListesiYukle(Controller controller, int kurumId);

        void YilListesiYukle(Controller controller, StratejikPlan sp);

    }

    //public class KavisHelper : IKavisHelper
    //{
    //    public KavisUser GetUser()
    //    {
    //        GenelKodlar genel = new GenelKodlar();

    //        ////Oturumdan kullanıcıyı al            
    //        KullaniciBilgileri kullanici = GenelKodlar.KullaniciCagir();
            

    //        if (kullanici != null)
    //        {
    //            ////Kavis Kurumunu bul
    //            KurumManager kurumManager = new KurumManager();
    //            Kurum kurum = kurumManager.GetByKurumKodu(kullanici.Kurum); //134954 İl milli eğitim

    //            //Admin veya Kavis Yönetici Kullanıcısı mı?
    //            if (kullanici.Seviye == 54 || kullanici.Seviye == 100)
    //            {
    //                kurum = kurumManager.GetByKurumKodu(134954);

    //                return new KavisUser
    //                {
    //                    Ad = kullanici.AdSoyad,
    //                    BirimAdi = "",
    //                    BirimId = 0,
    //                    KurumId = kurum.Id,
    //                    Type = KavisUserType.Admin,
    //                };

    //            }
    //            //Milli Eğitim Kullanıcısı mı?
    //            else if(kullanici.Kurum==134954 && kullanici.Seviye!=50)
    //            {
    //                var birimManager = new BirimManager();
    //                var birim = birimManager.GetByBurbisId(kullanici.Bolum);

    //                if (birim != null)
    //                {
    //                    return new KavisUser
    //                    {
    //                        Ad = kullanici.AdSoyad,
    //                        BirimAdi = birim.Baslik,
    //                        BirimId = birim.Id,
    //                        KurumId = kurum.Id,
    //                        Type = KavisUserType.Birim,
    //                    };
    //                }
    //                else
    //                    throw new Exception("Kullanıcının Birimi Bulunamadı.Birim listesinde birimin olup olmadığını kontrol edin");


    //            }
    //            //Kurum kullanıcısı mı?
    //            else if (kullanici.Seviye==50 || kullanici.Seviye == 99)
    //            {
    //                if (kurum != null)
    //                {
    //                    return new KavisUser
    //                    {
    //                        Ad = kullanici.AdSoyad,
    //                        BirimAdi = "",
    //                        BirimId = 0,
    //                        KurumId = kullanici.Kurum,
    //                        Type = KavisUserType.Kurum,
    //                    };

    //                }
    //                else
    //                    throw new Exception("Kurum bulunamadı");

    //            }

    //        }
            
    //        return null;
    //    }

    //    public void BirimListesiYukle(Controller controller, int kurumId)
    //    {
    //        KavisUser kavisUser = GetUser();

    //        BirimManager birimManager = new BirimManager(new EfBirimDal());

    //        var birimler = birimManager.GetAll(kurumId);

    //        List<SelectListItem> birimSelectList = (from x in birimler select new SelectListItem { Value = x.Id.ToString(), Text = x.Baslik }).ToList();

    //        controller.ViewBag.BirimSelectList = birimSelectList;
    //    }

    //    public void YilListesiYukle(Controller controller, StratejikPlan sp)
    //    {
    //        List<SelectListItem> listItems = new List<SelectListItem>();

    //        int baslangic = 0;

    //        if (sp != null)
    //            baslangic = sp.Baslangic;

    //        for (int i = 0; i < 5; i++)
    //        {
    //            listItems.Add(new SelectListItem() { Value = (i + 1).ToString(), Text = (baslangic + i).ToString() });
    //        }

    //        controller.ViewBag.YilListesi = listItems;
    //    }


    //}



}