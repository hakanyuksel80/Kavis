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
        bool DeletePlan(int id);
        
        Amac GetAmac(int id);
        void DeleteAmac(Amac amac);
        List<Strateji> GetAllStratejiByBirim(int birim);
        List<FaaliyetListView> GetAllFaaliyetByBirim(int birim);
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
        StratejikPlan GetAktifStratejikPlan();
        Eylem GetEylem(int id);
        void DeleteEylem(Eylem eylem);
        void AddEylem(Eylem eylem);


        Faaliyet GetFaaliyet(int id);
        void DeleteFaaliyet(Faaliyet faaliyet);
        void AddFaaliyet(Faaliyet faaliyet);

        void SaveChanges();
        List<Strateji> GetAllStrateji(int planId);
        List<Eylem> GetListEylemByStrateji(int id);

        
    }
}
