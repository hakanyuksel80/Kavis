using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Enitites.DbModels;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Birimler
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Birimler/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Birimler/5
        public void Delete(int id)
        {
        }
    }
}
