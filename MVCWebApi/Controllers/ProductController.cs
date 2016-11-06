using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebApi.Controllers
{
    public interface ITest
    {
        void Foo();
    }

    public class Test : ITest
    {
        public void Foo()
        {
        }
    }

    public class ProductController : ApiController
    {
        private ITest _test;
        public ProductController(ITest test)
        {
            _test = test;
        }

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return Products.instance.ProductList;
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return Products.instance.ProductList.Where(p => p.ProductId == id).FirstOrDefault();
        }

        // POST: api/Product
        public void Post([FromBody]Product product)
        {
            Products.instance.ProductList.Add(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product product)
        {
            Products.instance.ProductList.Add(product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
