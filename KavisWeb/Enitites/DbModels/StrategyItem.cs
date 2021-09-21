using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

    public interface IStratejiTipi
    {
        int Id { get; set; }

        string State { get; set; }
    }

    public class StratejiTipi : IEntity, IStratejiTipi
    {
        public int Id { get; set; }

        public string Kod { get; set; }

        public string Baslik { get; set; }

        public int SiraNo { get; set; }

        [NotMapped]
        public string State { get; set; }

    }

    [Table("Amaclar")]
    public class Amac : StratejiTipi
    {

        public int StratejikPlanId { get; set; }

        [JsonIgnore]
        public virtual StratejikPlan StratejikPlan { get; set; }

        public virtual List<Hedef> Hedefler { get; set; }
    }

    [Table("Hedefler")]
    public class Hedef : StratejiTipi
    {
        [JsonIgnore]
        public Amac Amac { get; set; }

        public virtual List<Gosterge> Gostergeler { get; set; }

        public virtual List<Strateji> Stratejiler { get; set; }
    }

    [Table("Stratejiler")]
    public class Strateji : StratejiTipi
    {
        [JsonIgnore]
        public Hedef Hedef { get; set; }

        public List<Eylem> Eylemler { get; set; }
    }

    [Table("Gostergeler")]
    public class Gosterge : StratejiTipi
    {
        [JsonIgnore]
        public Hedef Hedef { get; set; }

        public string HedefeEtkisi { get; set; }

        public string Baslangic { get; set; }

        public string Yil1 { get; set; }

        public string Yil2 { get; set; }

        public string Yil3 { get; set; }

        public string Yil4 { get; set; }

        public string Yil5 { get; set; }

        public string Yil1G { get; set; }

        public string Yil2G { get; set; }

        public string Yil3G { get; set; }

        public string Yil4G { get; set; }

        public string Yil5G { get; set; }

        public string Izleme { get; set; }

        public string Rapor { get; set; }

        public int SorumluBirimId { get; set; }

        public string SorumluBirim { get; set; }
    }

    [Table("Eylemler")]
    public class Eylem : StratejiTipi
    {
        public string Birim { get; set; }

        public int StratejiId { get; set; }

        [JsonIgnore]
        public Strateji Strateji { get; set; }
    }

    [Table("Faaliyetler")]
    public class Faaliyet
    {

        public int Id { get; set; }

        public int EylemId { get; set; }

        [JsonIgnore]
        public Eylem Eylem { get; set; }

        public string Adi { get; set; }

        public string Gerceklesme { get; set; }

        public string Sonuc { get; set; }

        public string Durum { get; set; }

    }


    [Table("Plans")]
    public class StratejikPlan : IEntity
    {
        public int Id { get; set; }

        public int KurumKodu { get; set; }

        public string KurumAdi { get; set; }

        public int Baslangic { get; set; }

        public int Bitis { get; set; }

        public KurumTipi KurumTipi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public List<Amac> Amaclar { get; set; }

    }







}