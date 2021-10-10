using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.DbModels
{
    [Table("Birimler")]
    public class Birim : IEntity
    {
        public int Id { get; set; }

        public int BurbisId { get; set; }

        public string Kodu { get; set; }

        public string Baslik { get; set; }

        public int? KurumId { get; set; }

        [JsonIgnore]
        public Kurum Kurum { get; set; }


    }


}