using KavisWeb.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.BusinessLayer
{
    public class KavisHelper
    {
        public static KavisUser GetUser()
        {
            return new KavisUser
            {
                KurumId = 2,

                Ad = "Hakan YÜKSEL",

                Type = KavisUserType.Admin,

                BirimId = 1,
            };

        }
    }
}