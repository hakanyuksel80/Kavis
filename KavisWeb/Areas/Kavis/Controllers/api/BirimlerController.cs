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
    public class BirimlerController : ApiController
    {

        BirimManager birimManager;

        public BirimlerController()
        {
            birimManager = new BirimManager(new EfBirimDal());
        }

        // GET: api/Birimler
        public IEnumerable<Birim> Get()
        {
            return birimManager.GetAll();

        }

        // GET: api/Birimler/5
        public Birim Get(int id)
        {
            var birim = birimManager.Get(id);
            return birim;
        }

        // POST: api/Birimler
        public IResult Post(Birim model)
        {
            if (model.Id > 0)
            {
                if (birimManager.Update(model))
                    return new SuccessResult();

                return new ErrorResult();
                    
            } else
            {
                if (birimManager.Add(model))
                    return new SuccessDataResult<Birim>(model);
                
                return new ErrorResult();
            }
        }

        // DELETE: api/Birimler/5
        public IResult Delete(int id)
        {
            if (birimManager.Delete(id))
                return new SuccessResult();
            else
                return new ErrorResult();
        }
    }
}
