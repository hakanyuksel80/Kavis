using KavisWeb.Enitites.DbModels;
using KavisWeb.Enitites.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KavisWeb.BusinessLayer
{
    public interface IStratejikPlanService
    {
        StratejikPlan GetPlan(int id);

        List<StratejikPlanListView> GetViewList();
        
        void SavePlan(StratejikPlan plan);      
        void DeletePlan(int id);
        
        Amac GetAmac(int id);
        void DeleteAmac(Amac amac);
        List<Strateji> GetAllStratejiByBirim(string birim);
        List<FaaliyetListView> GetAllFaaliyetByBirim(string birim);
        void SaveAmac(Amac amac);
        
        Hedef GetHedef(int id);
        void DeleteHedef(Hedef hedef);
        void SaveHedef(Hedef hedef);
        
        Strateji GetStrateji(int id);
        void DeleteStrateji(Strateji strateji);
        void SaveStrateji(Strateji strateji);
        
        Gosterge GetGosterge(int id);
        void DeleteGosterge(Gosterge gosterge);
        void SaveGosterge(Gosterge gosterge);


        void SaveChanges();
        List<Strateji> GetAllStrateji(int planId);
        List<Eylem> GetListEylemByStrateji(int id);

        Eylem GetEylem(int id);
    }
}
