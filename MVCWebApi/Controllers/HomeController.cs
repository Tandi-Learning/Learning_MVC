using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApi.Controllers
{
    public class InputData
    {
        public string Message { get; set; }
        public string Dummy { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult Copyright(InputData inData)
        {
            return PartialView("", inData);
        }
    }
}
