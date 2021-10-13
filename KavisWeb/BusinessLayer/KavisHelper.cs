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
    public class KavisHelper
    {
        public static KavisUser GetUser()
        {
            // Ev de
            //return new KavisUser
            //{
            //    KurumId = 1,

            //    Ad = "Hakan YÜKSEL",

            //    Type = KavisUserType.Kurum,

            //    BirimId = 2,

            //    BirimAdi = "TEMEL EĞİTİM",
            //};

            // ÖDM
            return new KavisUser
            {
                KurumId = 2,

                Ad = "Hakan YÜKSEL",

                Type = KavisUserType.Kurum,

                BirimId = 55,

                BirimAdi = "TEMEL EĞİTİM",
            };

        }

        public static void BirimListesiYukle(Controller controller, int kurumId)
        {
            KavisUser kavisUser = GetUser();

            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var birimler = birimManager.GetAll(kurumId);

            List<SelectListItem> birimSelectList = (from x in birimler select new SelectListItem { Value = x.Id.ToString(), Text = x.Baslik }).ToList();

            controller.ViewBag.BirimSelectList = birimSelectList;
        }

        public static void YilListesiYukle(Controller controller, StratejikPlan sp)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            int baslangic = 0;

            if (sp != null)
                baslangic = sp.Baslangic;

            for (int i = 0; i < 5; i++)
            {
                listItems.Add(new SelectListItem() { Value = (i + 1).ToString(), Text = (baslangic + i).ToString() });
            }

            controller.ViewBag.YilListesi = listItems;
        }

        

    }



}