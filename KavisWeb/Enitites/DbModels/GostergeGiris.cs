using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KavisWeb.Enitites.DbModels
{
    [Table("GostergeGirisleri")]
    public class GostergeGiris : IEntity
    {
        public int Id { get; set; }

        public int GostergeId { get; set; }

        public Gosterge Gosterge { get; set; }

        public byte Yil { get; set; }        

        public int BirimId { get; set; }

        public Birim Birim { get; set; }        

        public bool Onay { get; set; }
        
        public string Deger { get; set; }
    }
}