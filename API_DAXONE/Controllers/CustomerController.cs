using API_DAXONE.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DAXONE.Controllers
{
    public class CustomerController : ApiController
    {
        private DaxoneEntities daxoneEntities = new DaxoneEntities();
        // GET: api/Customer
        public HttpResponseMessage Get()
        {
            try
            {
                var result = daxoneEntities.Customers.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Customer/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Product product = daxoneEntities.Products.Find(id);
                return product != null ? Request.CreateResponse(HttpStatusCode.Found, product) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Customer
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
