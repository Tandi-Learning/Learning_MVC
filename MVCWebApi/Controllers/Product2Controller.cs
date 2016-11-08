using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVCWebApi.Controllers
{
    public class Product2Controller : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            IEnumerable<Product> products = Products.instance.ProductList;

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
            return response;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class Product3Controller : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<Product> products = Products.instance.ProductList;
            //            return Ok<IEnumerable<Product>>(products);
            return new ProductsResult(products, Request);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class ProductsResult : IHttpActionResult
    {
        private IEnumerable<Product> _products;
        private HttpRequestMessage _request;

        public ProductsResult(IEnumerable<Product> products, HttpRequestMessage request)
        {
            _products = products;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                Content = new ObjectContent<IEnumerable<Product>>(_products, new JsonMediaTypeFormatter()),
                RequestMessage = _request
            };

            return Task.FromResult(response);
        }
    }
}