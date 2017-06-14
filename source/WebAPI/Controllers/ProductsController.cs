using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private List<Product> products = new List<Product>();

        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }

        [HttpPost]
        public void Post([FromBody] string name)
        {
            if(!string.IsNullOrEmpty(name))
            products.Add(new Product(name));
        }

        [HttpDelete]
        public void Delete(string name)
        {
            products.RemoveAt(products.IndexOf(products.First(x => x.Name.Equals(name))));
        }
    }
}
