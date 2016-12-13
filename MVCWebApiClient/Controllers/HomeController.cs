using MVCWebApiClient.Handler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCWebApiClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UseHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            // ** Method 1. Use GetAsync and ReadAsStringAsync **
            //HttpResponseMessage response = client.GetAsync(new Uri("http://localhost:55467/api/Product")).Result;
            //string content = response.Content.ReadAsStringAsync().Result;

            // ** Method 2. Use GetStringAsync **
            //string content = client.GetStringAsync(new Uri("http://localhost:55467/api/Product")).Result;

            // ** Method 3. Use GetAsync and ReadAsStringAsync (fluid) **
            string content = string.Empty;
            var task = client.GetAsync(new Uri("http://localhost:55467/api/Product")).ContinueWith(
                (taskResponse) =>
                {
                    var response = taskResponse.Result;
                    var taskRead = response.Content.ReadAsStringAsync();
                    taskRead.Wait();
                    content = taskRead.Result;
                }
            );
            task.Wait();

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(content);

            return View(products); //Json(new { ProductsResul = products }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UseHttpClient2()
        {
            // just another play sample of HttpClient
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("http://api.worldbank.org/countries?format=json").Result;
            response.EnsureSuccessStatusCode();
            JArray content = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);
            List<Country> countries = new List<Country>();
            foreach (var country in content[1])
            {
                countries.Add(new Country
                {
                    Name = country.Value<string>("name"),
                    CapitalCity = country.Value<string>("capitalCity"),
                    ISO2Code = country.Value<string>("iso2Code"),
                });               
            }

            return View(countries); //Json(new { Countries = countries }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UseHttpClient3()
        {
            // Using HttpMessageHandler
            HttpClient client = new HttpClient(new MyHttpClientHandler2());
            string responseString = client.GetAsync("http://api.worldbank.org/countries?format=json").ContinueWith(
                (requestTask) =>
                {
                    HttpResponseMessage response = requestTask.Result;
                    return response.Content.ReadAsStringAsync().Result;
                }).Result;
            return Content(responseString);
        }

        public ActionResult UseWebClient()
        {
            return Json(new { value = "UseWebClient" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UseHttpWebRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:55467/api/Product");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            string data = streamReader.ReadToEnd();

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(data);

            return Json(new { ProductsResult = products }, JsonRequestBehavior.AllowGet);
        }
    }
}