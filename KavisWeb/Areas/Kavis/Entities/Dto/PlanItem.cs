using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Dto
{
    public class PlanItemDto
    {
        public int Id { get; set; }

        public int SiraNo { get; set; }

        public string Baslik { get; set; }

        public string No { get; set; }

        public string State { get; set; }

        public int ParentId { get; set; }

        public string Birim { get; set; }

    }

    public class ParentPlanItemDto : PlanItemDto
    {
        public List<ParentPlanItemDto> Items { get; set; }
    }

    
}