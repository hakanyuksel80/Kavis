using KavisWeb.Entities;
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
            // Ev de
            //return new KavisUser
            //{
            //    KurumId = 1,

            //    Ad = "Hakan YÜKSEL",

            //    Type = KavisUserType.Birim,

            //    BirimId = 2,
            //};

            // ÖDM
            return new KavisUser
            {
                KurumId = 2,

                Ad = "Hakan YÜKSEL",

                Type = KavisUserType.Birim,

                BirimId = 55,
            };

        }
    }
}