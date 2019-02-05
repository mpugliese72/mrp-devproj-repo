using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Core;

namespace MinViableProduct.Controllers
{
    [Route("api/product")]
    public class ProductController : ApiController
    {
        public string _jsonFile = ConfigurationSettings.AppSettings.Get("ProductFile");

        //GET api/products
        [HttpGet]
        [Route("~/api/get")]
        public IEnumerable<Product> Get()
        {
            var products = new Products(_jsonFile);
            var allProducts = products.Items.ToList<Product>();
            return allProducts;
        }

        // GET api/products/id
        [HttpGet]
        [Route("~/api/get/id")]
        public Product Get(int id)
        {
            var products = new Products(_jsonFile);

            var product = products.Items.Where(p => p.id == id).FirstOrDefault();
            return product; 
        }

        // GET api/products/state
        [HttpGet]
        [Route("~/api/get/state")]
        public IEnumerable<Product> GetByState(string state)
        {
            var products = new Products(_jsonFile);

            var product = products.Items.Where(p => p.consumer.state == state).ToList<Product>();
            return product;
        }

        // GET api/products/make
        [HttpGet]
        [Route("~/api/get/make")]
        public IEnumerable<Product> GetByMake(string make)
        {
            var products = new Products(_jsonFile);

            var product = products.Items.Where(p => p.vehicle.Any(v => v.make.ToUpper() == make.ToUpper())).ToList<Product>();
            return product;
        }

        // GET api/products/former_insurer
        [HttpGet]
        [Route("~/api/get/former_insurer")]
        public IEnumerable<Product> GetByInsurer(string former_insurer)
        {
            var products = new Products(_jsonFile);

            var product = products.Items.Where(p => p.coverage.former_insurer == former_insurer).ToList<Product>();
            return product;
        }
    }
}
