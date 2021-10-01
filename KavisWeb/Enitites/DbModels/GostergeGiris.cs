using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Enitites.DbModels
{
    public class GostergeGiris
    {
        public int Id { get; set; }

        public int GostergeId { get; set; }

        public Gosterge Gosterge { get; set; }

        public byte Yil { get; set; }        

        public int BirimId { get; set; }

        public Birim Birim { get; set; }        

        public bool Onay { get; set; }
        
    }
}