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
                Customer customer = daxoneEntities.Customers.Find(id);
                return customer != null ? Request.CreateResponse(HttpStatusCode.Found, customer) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            try
            {
                daxoneEntities.Customers.Add(customer);
                daxoneEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Customer/5
        public HttpResponseMessage Put(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer cus = daxoneEntities.Customers.Find(id);
                cus.Password = customer.Password;
                cus.Name = customer.Name;
                cus.Address = customer.Address;
                cus.Email = customer.Email;
                cus.Phone = customer.Phone;
                cus.DateOfBirth = customer.DateOfBirth;
                cus.Avatar = customer.Avatar;
                daxoneEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Customer/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Customer customer = daxoneEntities.Customers.Find(id);
                if (customer != null)
                {
                    daxoneEntities.Customers.Remove(customer);
                    daxoneEntities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage getOrder(int idCus)
        {
            try
            {
                Customer customer = daxoneEntities.Customers.Find(idCus);
                return Request.CreateResponse(HttpStatusCode.OK, customer.Orders);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
