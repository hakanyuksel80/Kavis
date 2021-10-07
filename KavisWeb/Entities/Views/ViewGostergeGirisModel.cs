using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Views
{
    public class ViewGostergeGirisModel
    {
        public Birim Birim { get; set; }

        public StratejikPlan Plan { get; set; }
    }
}