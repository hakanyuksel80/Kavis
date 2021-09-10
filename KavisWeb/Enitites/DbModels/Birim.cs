using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Enitites.DbModels
{
    public class Birim
    {
        public int Id { get; set; }

        public int BurbisId { get; set; }

        public string Kodu { get; set; }

        public string Baslik { get; set; }

    }
}