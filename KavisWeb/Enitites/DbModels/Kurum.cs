using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KavisWeb.Enitites.DbModels
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

    }
}