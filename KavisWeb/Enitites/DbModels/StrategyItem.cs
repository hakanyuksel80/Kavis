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

    [Table("Plans")]
    public class StratejikPlan : IEntity
    {
        public int Id { get; set; }

        public int Baslangic { get; set; }

        public int Bitis { get; set; }

        public virtual Kurum Kurum { get; set; }

        public int? KurumId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public List<Amac> Amaclar { get; set; }




    }

    [Table("Amaclar")]
    public class Amac : StratejiTipi
    {

        public int StratejikPlanId { get; set; }

        [JsonIgnore]
        public virtual StratejikPlan StratejikPlan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual List<Hedef> Hedefler { get; set; }
    }

    [Table("Hedefler")]
    public class Hedef : StratejiTipi
    {
        [JsonIgnore]
        public Amac Amac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public virtual List<Gosterge> Gostergeler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        public string GetHedefDegerler(byte yil)
        {
            switch (yil)
            {
                case 1: return Yil1;
                case 2: return Yil2;
                case 3: return Yil3;
                case 4: return Yil4;
                case 5: return Yil5;
            }

            return "";
        }

        public void SetHedefDegerler(byte yil,string value)
        {
            switch (yil)
            {
                case 1: Yil1 = value;break;                
                case 2: Yil2 = value;break;                
                case 3: Yil3 = value;break;                
                case 4: Yil4 = value;break;                
                case 5: Yil5 = value; break;                
            }
            
        }

        public string GetGerceklesenDegerler(byte yil)
        {
            switch (yil)
            {
                case 1: return Yil1G;
                case 2: return Yil2G;
                case 3: return Yil3G;
                case 4: return Yil4G;
                case 5: return Yil5G;
            }

            return "";
        }

        public void SetGerceklesenDeger(byte yil, string value)
        {
            switch (yil)
            {
                case 1: Yil1G = value; break;
                case 2: Yil2G = value; break;
                case 3: Yil3G = value; break;
                case 4: Yil4G = value; break;
                case 5: Yil5G = value; break;
            }

        }

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
    public class Faaliyet : StratejiTipi
    {

        public int EylemId { get; set; }

        [JsonIgnore]
        public Eylem Eylem { get; set; }

        public byte Yil { get; set; }

        public DateTime Baslama { get; set; }

        public DateTime Bitis { get; set; }

        public string Gerceklesme { get; set; }

        public string Sonuc { get; set; }

        public string Durum { get; set; }

        public int Birim { get; set; }

        public string BirimAdi { get; set; }

        public bool Onay1 { get; set; }

        public bool Onay2 { get; set; }

    }










}