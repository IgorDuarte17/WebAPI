using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private List<ProductModel> products = new List<ProductModel>();

        [HttpGet]
        public List<ProductModel> Get()
        {
            return products;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ProductModel product)
        {
            try
            {
                List<ProductModel> products = new List<ProductModel>();

                if (product.Name != null)
                {
                    products.Add(new ProductModel() { Name = product.Name });
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(ProductModel product)
        {
            try
            {
                products.RemoveAt(products.IndexOf(products.First(x => x.Name.Equals(product.Name))));
                return Request.CreateResponse(HttpStatusCode.OK, "Produto: " + product.Name + "Deletado!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
