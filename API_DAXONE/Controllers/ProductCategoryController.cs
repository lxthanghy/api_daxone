using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DAXONE.Controllers
{
    public class ProductCategoryController : ApiController
    {
        // GET: api/ProductCategory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductCategory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductCategory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductCategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductCategory/5
        public void Delete(int id)
        {
        }
    }
}
