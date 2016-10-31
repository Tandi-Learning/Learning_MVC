using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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

            HttpResponseMessage response = client.GetAsync(new Uri("http://localhost:55467/api/Product")).Result;
            string content = response.Content.ReadAsStringAsync().Result;
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(content);

            return Json(new { ProductsResult = products }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UseWebClient()
        {
            return Json(new { value = "UseWebClient" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UseHttpWebRequest()
        {
            return Json(new { value = "UseHttpWebRequest" }, JsonRequestBehavior.AllowGet);
        }
    }
}