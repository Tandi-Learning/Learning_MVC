using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LearningSvcRef.ServiceClient svcObj = new LearningSvcRef.ServiceClient();
            string value = svcObj.GetData(10);
            return View((object)value);
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
    }
}