using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KavisWeb.BusinessLayer
{
    public interface IGostergeGirisService
    {
        GostergeGiris GetByBirim(int birimId, int gostergeId, byte yil);
    }
}
