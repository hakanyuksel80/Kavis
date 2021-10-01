using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KavisWeb.Enitites.DbModels
{
    [Table("Birimler")]
    public class Birim : IEntity
    {
        public int Id { get; set; }

        public int BurbisId { get; set; }

        public string Kodu { get; set; }

        public string Baslik { get; set; }

        public Kurum Kurum { get; set; }

        public int KurumId { get; set; }

    }


}