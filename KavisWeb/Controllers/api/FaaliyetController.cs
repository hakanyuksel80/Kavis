using Core.Utilities.Results;
using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KavisWeb.Controllers.api
{
    public class FaaliyetController : ApiController
    {
        FaaliyetManager manager = new FaaliyetManager(new EfFaaliyetDal());

        // GET: api/Faaliyet
        public IEnumerable<Faaliyet> Get()
        {
            var kavisUser = KavisHelper.GetUser();

            return manager.GetAll(kavisUser.BirimId);
        }

        // GET: api/Faaliyet/5
        public Faaliyet Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Faaliyet
        public IResult Post(Faaliyet model)
        {        

            if (model.Id == 0)
            {
                if (manager.Add(model))
                    return new SuccessDataResult<Faaliyet>(model);
            }
            else
                if (manager.Update(model))
                return new SuccessDataResult<Faaliyet>(model);

            return new ErrorResult("Kayıt yapılamadı");
        }

        // DELETE: api/Faaliyet/5
        public IResult Delete(int id)
        {
            if (manager.Delete(id))
                return new SuccessResult();
            else
                return new ErrorResult();
        }
    }
}
