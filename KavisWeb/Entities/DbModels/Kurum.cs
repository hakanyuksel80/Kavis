using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.DbModels
{
    public enum KurumTipi
    {
        Il,
        Ilce,
        Okul,
    }

    [Table("Kurumlar")]
    public class Kurum : IEntity
    {
        public int Id { get; set; }

        public int KurumKodu { get; set; }        

        public string Adi { get; set; }

        public KurumTipi Turu { get; set; }

        public List<Birim> Birimler { get; set; }        

        public int? AktifPlanId { get; set; }

        public int AktifYil { get; set; }

        public bool FaaliyetGirisAcik { get; set; }

        public bool FaaliyetDurumGirisAcik { get; set; }

        public bool GostergeGirisAcik { get; set; }

        public string Mesaj { get; set; }


    }
}