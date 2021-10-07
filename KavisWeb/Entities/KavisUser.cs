using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities
{

    public enum KavisUserType { Admin, Kurum, Birim }

    public class KavisUser
    {
        public KavisUserType Type { get; set; }

        public string Ad { get; set; }

        public int KurumId { get; set; }

        public int BirimId { get; set; }

    }
}