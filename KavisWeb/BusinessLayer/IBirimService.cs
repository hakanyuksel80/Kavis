using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KavisWeb.BusinessLayer
{
    public interface IBirimService
    {
        List<Birim> GetAll();
    }
}
