using API_DAXONE.DTO;
using API_DAXONE.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DAXONE.Controllers
{
    public class ProductController : ApiController
    {
        private DaxoneEntities daxoneEntities = new DaxoneEntities();
        // GET: api/Product
        public IQueryable<ProductDTO> Get()
        {
            try
            {
                var result = from pro in daxoneEntities.Products
                             select new ProductDTO
                             {
                                 ID = pro.ID,
                                 Name = pro.Name,
                                 MetaTitle = pro.MetaTitle,
                                 Price = pro.Price,
                                 Quantity = pro.Quantity,
                                 Frame = pro.Frame,
                                 Rims = pro.Rims,
                                 Tires = pro.Tires,
                                 Weight = pro.Weight,
                                 WeightLimit = pro.WeightLimit,
                                 CreatedDate = pro.CreatedDate
                             };
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: api/Product/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Product product = daxoneEntities.Products.SingleOrDefault(x => x.ID == id);
                if (product != null)
                {
                    ProductDTO productDTO = new ProductDTO();
                    productDTO.ID = product.ID;
                    productDTO.Name = product.Name;
                    productDTO.MetaTitle = product.MetaTitle;
                    productDTO.Price = product.Price;
                    productDTO.Quantity = product.Quantity;
                    productDTO.Frame = product.Frame;
                    productDTO.Rims = product.Rims;
                    productDTO.Tires = product.Tires;
                    productDTO.Weight = product.Weight;
                    productDTO.WeightLimit = product.WeightLimit;
                    productDTO.CreatedDate = product.CreatedDate;
                    return Request.CreateResponse(HttpStatusCode.OK, productDTO);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody] Product product)
        {
            try
            {
                daxoneEntities.Products.Add(product);
                daxoneEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Product/5
        public HttpResponseMessage Put(int id, [FromBody] Product product)
        {
            try
            {
                Product pro = daxoneEntities.Products.Find(id);
                if (pro != null)
                {
                    pro.Name = product.Name;
                    pro.MetaTitle = product.MetaTitle;
                    pro.Price = product.Price;
                    pro.Quantity = product.Quantity;
                    pro.Frame = product.Frame;
                    pro.Rims = product.Rims;
                    pro.Tires = product.Tires;
                    pro.Weight = product.Weight;
                    pro.WeightLimit = product.WeightLimit;
                    pro.CreatedDate = product.CreatedDate;
                    daxoneEntities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Product product = daxoneEntities.Products.Find(id);
                if (product != null)
                {
                    daxoneEntities.Products.Remove(product);
                    daxoneEntities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage SearchProduct(string name, decimal s, decimal e)
        {
            try
            {
                var res = daxoneEntities.Products
                    .Where(x => x.Name.ToLower().IndexOf(name.ToLower()) >= 0 && x.Price >= s && x.Price <= e)
                    .Select(x => new ProductDTO()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        MetaTitle = x.MetaTitle,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Frame = x.Frame,
                        Rims = x.Rims,
                        Tires = x.Tires,
                        Weight = x.Weight,
                        WeightLimit = x.WeightLimit,
                        CreatedDate = x.CreatedDate
                    });
                //var result = from pro in daxoneEntities.Products
                //             where pro.Name.ToLower().IndexOf(name.ToLower()) >= 0
                //             select new ProductDTO
                //             {
                //                 ID = pro.ID,
                //                 Name = pro.Name,
                //                 MetaTitle = pro.MetaTitle,
                //                 Price = pro.Price,
                //                 Quantity = pro.Quantity,
                //                 Frame = pro.Frame,
                //                 Rims = pro.Rims,
                //                 Tires = pro.Tires,
                //                 Weight = pro.Weight,
                //                 WeightLimit = pro.WeightLimit,
                //                 CreatedDate = pro.CreatedDate
                //             };
                return Request.CreateResponse(HttpStatusCode.Found, res);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
