using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning_MVC.Controllers
{
    public class Lesson1Controller : Controller
    {
        // GET: Lesson1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JQueryPromises()
        {
            return View();
        }

        public ActionResult GetMovies()
        {
            var movie = new List<object>();

            movie.Add(new { Title = "Ghostbusters", Genre = "Comedy", Year = 1984 });
            movie.Add(new { Title = "Gone with Wind", Genre = "Drama", Year = 1939 });
            movie.Add(new { Title = "Star Wars", Genre = "Science Fiction", Year = 1977 });

            return Json(movie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMusic()
        {
            var music = new List<object>();

            music.Add(new { Title = "Dystopia", Genre = "Heavy Metal", Year = 2016 });
            music.Add(new { Title = "Invisible Touch", Genre = "Pop", Year = 1986 });
            music.Add(new { Title = "Pure At Heart", Genre = "Instrumental", Year = 2013 });

            return Json(music, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModulesInject()
        {
            return View();
        }

        public ActionResult TSHelloWorld()
        {
            return View();
        }
    }
}