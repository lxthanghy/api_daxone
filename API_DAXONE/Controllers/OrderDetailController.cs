using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DAXONE.Controllers
{
    public class OrderDetailController : ApiController
    {
        // GET: api/OrderDetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderDetail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderDetail
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrderDetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderDetail/5
        public void Delete(int id)
        {
        }
    }
}
