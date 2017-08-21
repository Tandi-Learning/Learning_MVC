using Learning_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Learning_MVC.Controllers
{
    public class Lesson2Controller : Controller
    {
        private IQueryable<BookModels> allBooksQueryable;
        private IEnumerable<BookModels> allBooksEnumerable;

        private void InitBookModels()
        {
            allBooksQueryable = SeedBooks().AsQueryable();
            allBooksEnumerable = SeedBooks().AsEnumerable();
        }

        private List<BookModels> SeedBooks()
        {
            return new List<BookModels> {
                new BookModels { Title = "dBase IV", Author = "Alan Simpson", PublishedYear = 1993 },
                new BookModels { Title = "Docker Up & Running", Author = "Karl Mathiasa", PublishedYear = 2015 },
                new BookModels { Title = "Complet Guide to Angular 4", Author = "Nathan Murray", PublishedYear = 2017 },
            };
        }

        // GET: Lesson2
        public ActionResult IEnumerableLesson()
        {
            InitBookModels();
            int publishedYear = 2010;

            Func<BookModels, bool> predicate = m => m.PublishedYear > 2002;
            Expression<Func<BookModels, bool>> predicateExpr = m => m.PublishedYear > 2015;

            // defer execution. All result is brought back and then where filter is applied
            var result = allBooksQueryable.Where(predicate);

            // defer execution. Where filter expression is sent to server and converted to SQL, only matched result is returned
            var resultExpr = allBooksQueryable.Where(predicateExpr);

            return View(resultExpr);
        }

        private string Test()
        {
            return "Karl Mathiasa";
        }
    }
}
