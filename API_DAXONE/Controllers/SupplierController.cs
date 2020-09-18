using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_DAXONE.Models;
namespace API_DAXONE.Controllers
{
    public class SupplierController : ApiController
    {
        private DaxoneEntities daxoneEntities = new DaxoneEntities();
        // GET: api/Supplier
        public HttpResponseMessage Get()
        {
            try
            {
                var result = daxoneEntities.Suppliers.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Supplier/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Supplier supplier = daxoneEntities.Suppliers.Find(id);
                return supplier != null ? Request.CreateResponse(HttpStatusCode.Found, supplier) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Supplier
        public HttpResponseMessage Post([FromBody]Supplier supplier)
        {
            try
            {
                daxoneEntities.Suppliers.Add(supplier);
                daxoneEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Supplier/5
        public HttpResponseMessage Put(int id, [FromBody] Supplier supplier)
        {
            try
            {
                Supplier sup = daxoneEntities.Suppliers.Find(id);
                sup.Name = supplier.Name;
                sup.Address = supplier.Address;
                sup.Email = supplier.Email;
                sup.Phone = supplier.Phone;
                daxoneEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Supplier/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Supplier supplier = daxoneEntities.Suppliers.Find(id);
                if (supplier != null)
                {
                    daxoneEntities.Suppliers.Remove(supplier);
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
    }
}
